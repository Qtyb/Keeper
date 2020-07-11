using RabbitMQ.Client;

namespace Common.EventBus.RabbitMq.Interfaces
{
    public interface IRabbitMqConnection
    {
        IConnection GetConnection();
    }
}