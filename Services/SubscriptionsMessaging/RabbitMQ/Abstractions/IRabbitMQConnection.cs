using System;
using RabbitMQ.Client;

namespace SubscriptionsMessaging.RabbitMQ.Abstractions
{
    public interface IRabbitMQConnection : IDisposable
    {
        bool IsConnected { get; }
        bool TryConnect();
        IModel CreateModel();
    }
}
