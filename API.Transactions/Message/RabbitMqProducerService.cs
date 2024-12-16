using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace API.Transactions.Message
{
    public class RabbitMqProducerService
    {
        private readonly string _hostName = "swroqeyu"; 
        private readonly string _queueName = "customer-limit-update";

        public void SendMessage(object message)
        {
            var factory = new ConnectionFactory() { Uri = new Uri("amqps://swroqeyu:9L0M3r8tIPuVz2cwF7xAUI5lSXbXOXNv@possum.lmq.cloudamqp.com/swroqeyu") };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var jsonMessage = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonMessage);

            channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
            Console.WriteLine(" [x] Sent {0}", jsonMessage);
        }
    }
}
