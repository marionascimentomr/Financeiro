namespace API.Customers.Message
{
    public class Worker : BackgroundService
    {
        private readonly RabbitMqConsumerService _consumerService;

        public Worker(RabbitMqConsumerService consumerService)
        {
            _consumerService = consumerService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _consumerService.StartConsumingAsync(stoppingToken);
        }
    }
}
