namespace BlazorDemo.Api.Configuration
{
    public class RabbitMqOptions
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string Queue { get; set; }
    }
}