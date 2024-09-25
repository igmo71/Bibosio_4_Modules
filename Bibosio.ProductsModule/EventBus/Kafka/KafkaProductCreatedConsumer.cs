using Bibosio.ProductsModule.EventBus.Events;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Bibosio.ProductsModule.EventBus.Kafka
{
    internal class KafkaProductCreatedConsumer : BackgroundService
    {
        private readonly string _topic;
        private readonly IConsumer<string, ProductCreatedEvent> _consumer;
        private readonly ILogger<KafkaProductCreatedConsumer> _logger;

        public KafkaProductCreatedConsumer(IConfiguration configuration, ILogger<KafkaProductCreatedConsumer> logger)
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
                .SetValueDeserializer(new KafkaDeserializer<ProductCreatedEvent>())
                .Build();

            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken сancellationToken)
        {
            _consumer.Subscribe(_topic);

            try
            {
                Task.Run(() =>
                {
                    while (!сancellationToken.IsCancellationRequested)
                    {
                        var consumeResult = _consumer.Consume(сancellationToken);

                        if (consumeResult != null)
                        {
                            _logger.LogDebug("ConsumeMessage {@MessageValue}", consumeResult.Message.Value);
                        }
                    }
                }, сancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ConsumeMessage - Exception {Message}", ex.Message);
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
