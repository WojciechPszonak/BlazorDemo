using BlazorDemo.Configuration;
using BlazorDemo.Contracts.Survey.Commands;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorDemo.Worker
{
    public class Worker : BackgroundService
    {
        private readonly IMediator mediator;
        private readonly ILogger<Worker> logger;
        private readonly RabbitMqOptions options;
        private IConnection connection;
        private IModel channel;

        public Worker(IMediator mediator,
            ILogger<Worker> logger,
            IOptions<RabbitMqOptions> options)
        {
            this.mediator = mediator;
            this.logger = logger;
            this.options = options.Value;
            InitRabbitMQ();
        }

        public override void Dispose()
        {
            channel.Close();
            connection.Close();
            base.Dispose();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var type = ea.BasicProperties.Type;
                    var message = Encoding.UTF8.GetString(body);

                    await HandleMessage(type, message);
                };
                channel.BasicConsume(queue: options.Queue, autoAck: true, consumer: consumer);
                await Task.Delay(1000, stoppingToken);
            }
        }

        private async Task HandleMessage(string type, string message)
        {
            if (type == "survey.add")
            {
                var command = JsonSerializer.Deserialize<AddSurveyCommand>(message);
                await mediator.Send(command);
            }
            else if (type == "survey.edit")
            {
                var command = JsonSerializer.Deserialize<EditSurveyCommand>(message);
                await mediator.Send(command);
            }
        }

        private void InitRabbitMQ()
        {
            var factory = new ConnectionFactory() { HostName = options.Host, Port = options.Port };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();

            channel.QueueDeclare(queue: options.Queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }
    }
}
