using API.Customers.Dtos;
using Pay.Domain.Interfaces.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace API.Customers.Message
{
    public class RabbitMqConsumerService
    {
        private readonly string _queueName = "customer-limit-update";
        private readonly IServiceProvider _serviceProvider;

        public RabbitMqConsumerService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartConsumingAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory()
            {
                Uri = new Uri("amqps://swroqeyu:9L0M3r8tIPuVz2cwF7xAUI5lSXbXOXNv@possum.lmq.cloudamqp.com/swroqeyu")
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var transactionMessage = JsonSerializer.Deserialize<TransactionMessage>(message);

                await UpdateCustomerLimitAsync(transactionMessage.CustomerId, transactionMessage.Value);
            };

            channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

            await Task.Delay(Timeout.Infinite, cancellationToken);
        }

        private async Task UpdateCustomerLimitAsync(Guid customerId, decimal transactionValue)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var customerDomainService = scope.ServiceProvider.GetRequiredService<ICustomerDomainService>();
                await customerDomainService.UpdateCustomerLimitAsync(customerId, transactionValue);
            }
        }

    }
}
