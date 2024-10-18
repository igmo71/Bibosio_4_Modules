using Bibosio.ProductsModule.Infrastructure.EventBus.Events;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Bibosio.ProductsModule.Infrastructure.EventBus.Kafka
{
    internal class KafkaProductCreatedConsumer : BackgroundService
    {
        private readonly string _topic;
        private readonly IConsumer<string, ProductCreatedEvent> _consumer;
        private readonly ILogger _logger;

        public KafkaProductCreatedConsumer(IConfiguration configuration)
        {
            _topic = configuration["Kafka:ProductCreatedTopic"]
                ?? throw new ApplicationException("Kafka ProductCreatedTopic not found");

            var config = new ConsumerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"],
                GroupId = "product-created-group",
                //AutoOffsetReset = AutoOffsetReset.Earliest, // Начать с самого раннего доступного оффсета
                //EnableAutoCommit = true // Автоматическая фиксация оффсетов
            };

            _consumer = new ConsumerBuilder<string, ProductCreatedEvent>(config)
                .SetValueDeserializer(new KafkaValueDeserializer<ProductCreatedEvent>())
                .Build();

            _logger = Log.ForContext<KafkaProductCreatedConsumer>();
        }

        protected override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _consumer.Subscribe(_topic);

            try
            {
                Task.Run(() =>
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var consumeResult = _consumer.Consume(cancellationToken);

                        if (consumeResult != null)
                        {
                            _logger.Debug("{Source} - Ok {@MessageValue}", "ConsumeMessage", consumeResult.Message.Value);
                        }
                    }
                }, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "{Source} - Exception {Message}", "ConsumeMessage", ex.Message);
            }

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _consumer.Dispose();
            base.Dispose();
        }
    }
}
