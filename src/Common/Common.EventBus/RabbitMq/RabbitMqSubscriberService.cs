using Common.EventBus.Interfaces;
using Common.EventBus.RabbitMq.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.EventBus.RabbitMq
{
    public class RabbitMqSubscriberService : IEventBusSubscriber
    {
        private readonly Dictionary<string, Type> _events = new Dictionary<string, Type>();

        private readonly IRabbitMqConnection _rabbitMqConnection;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<RabbitMqSubscriberService> _logger;
        private readonly string _queueName;
        private readonly string _exchangeName = "Keeper.Exchange";
        private IModel _channel;

        public RabbitMqSubscriberService(
            IRabbitMqConnection rabbitMqConnection,
            IConfiguration configuration,
            IServiceScopeFactory serviceScopeFactory,
            ILogger<RabbitMqSubscriberService> logger)
        {
            _rabbitMqConnection = rabbitMqConnection;
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;

            var rabbitMqSettings = configuration.GetSection("RabbitMq");
            _queueName = rabbitMqSettings["Queue"];
        }

        public void SetupSubscriber()
        {
            EnsureConnectionToRabbitMq();

            CreateExchange(_exchangeName);
            CreateQueue(_queueName);

            InitializeConsumer();
        }

        public void Subscribe<T>()
            where T : class
        {
            _logger.LogInformation($"Subscribing for topic [{typeof(T).Name}]");

            _events.Add(typeof(T).Name, typeof(T));
            _channel.QueueBind(_queueName, _exchangeName, typeof(T).Name);

            _logger.LogInformation($"Subscribed for topic [{typeof(T).Name}]");
        }

        private async Task OnEventReceived(object sender, BasicDeliverEventArgs @event)
        {
            try
            {
                var eventName = @event.RoutingKey;
                var eventType = _events[eventName];

                var body = Encoding.UTF8.GetString(@event.Body.ToArray());
                var message = JsonSerializer.Deserialize(body, eventType);

                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                    await mediator.Send(message);
                }

                _channel.BasicAck(@event.DeliveryTag, false);
            }
            catch (Exception ex)
            {
                var message = Encoding.UTF8.GetString(@event.Body.ToArray());
                _logger.LogError(ex, $"Error while retrieving message from queue. Message: {message}");

                _channel.BasicNack(@event.DeliveryTag, false, false);
            }
            finally
            {
                //EnsureConnectionToRabbitMq();
            }
        }

        private void EnsureConnectionToRabbitMq()
        {
            if (_channel is null || _channel.IsClosed)
            {
                _logger.LogInformation($"RabbitMq channel is not established. Trying to establish channel");

                _channel?.Close();
                _channel?.Dispose();
                _channel = null;

                _channel = _rabbitMqConnection.GetConnection().CreateModel();
                _channel.CallbackException += OnChannelCallbackException;
                _channel.ModelShutdown += OnModelShutdown;

                _logger.LogInformation($"RabbitMq channel is established");
            }
        }

        private void OnModelShutdown(object sender, ShutdownEventArgs e)
        {
            //TODO 2: finish
            _logger.LogError($"RabbitMq channel shutdown \nReply: [{e.ReplyText}]\nCause: [{e.Cause}]\nToString(): [{e}]");
        }

        private void OnChannelCallbackException(object sender, CallbackExceptionEventArgs e)
        {
            //TODO 2: finish
            _logger.LogError($"RabbitMq channel callback exception occured.\nException: [{e.Exception}]\nDetails: [{e.Detail}]\nToString(): [{e}]");
        }

        private void InitializeConsumer()
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.Received += OnEventReceived;

            _channel.BasicConsume(queue: _queueName, autoAck: false, consumer: consumer);
        }

        private void CreateExchange(string exchangeName)
        {
            _channel.ExchangeDeclare(exchangeName, ExchangeType.Direct, durable: true, autoDelete: false);
        }

        private void CreateQueue(string queueName)
        {
            _channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
        }


    }
}