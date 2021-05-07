using BlazorDemo.Configuration;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace BlazorDemo.Services.Infrastructure
{
    public class QueueService
    {
        private readonly RabbitMqOptions options;

        public QueueService(IOptions<RabbitMqOptions> options)
        {
            this.options = options.Value;
        }

        public void Send(string type, byte[] message)
        {
            var factory = new ConnectionFactory() { HostName = options.Host, Port = options.Port };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            var properties = channel.CreateBasicProperties();
            properties.Type = type;

            channel.QueueDeclare(queue: options.Queue, durable: false, exclusive: false, autoDelete: false, arguments: null);

            channel.BasicPublish(exchange: "", routingKey: options.Queue, basicProperties: properties, body: message);
        }

        public void Send(string type, string message)
        {
            Send(type, Encoding.UTF8.GetBytes(message));
        }

        public void Send<T>(string type, T obj)
        {
            Send(type, JsonSerializer.Serialize(obj));
        }
    }
}
