using Common.EventBus.Interfaces;
using Common.EventBus.RabbitMq;
using Common.EventBus.RabbitMq.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Common.EventBus.Extensions
{
    public static class EventBusExtensions
    {
        public static void AddEventBus(this IServiceCollection services)
        {
            services.AddSingleton<IRabbitMqConnection, RabbitMqConnection>();
            services.AddSingleton<IEventBusSubscriber, RabbitMqSubscriberService>();
            services.AddSingleton<IEventBusPublisher, RabbitMqPublisherService>();
        }
    }
}