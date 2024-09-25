using Bibosio.Interfaces;
using Bibosio.ProductsModule.Infrastructure.EventBus.Events;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Bibosio.ProductsModule.Infrastructure.EventBus.Kafka
{
    internal class KafkaProductCreatedProducer : IEventBusProducer<ProductCreatedEvent>
    {
        private readonly string _topic;
        private readonly IProducer<string, ProductCreatedEvent> _producer;
        private readonly ILogger _logger;

        public KafkaProductCreatedProducer(IConfiguration configuration)
        {
            _topic = configuration["Kafka:ProductCreatedTopic"]
                ?? throw new ApplicationException("Kafka ProductCreatedTopic not found");

            var config = new ProducerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"]
            };

            _producer = new ProducerBuilder<string, ProductCreatedEvent>(config)
                .SetValueSerializer(new KafkaValueSerializer<ProductCreatedEvent>())
                .Build();

            _logger = Log.ForContext<KafkaProductCreatedProducer>();
        }

        public async Task SendMessageAsync(string key, ProductCreatedEvent createdEvent)
        {
            try
            {
                var createdMessage = new Message<string, ProductCreatedEvent>
                {
                    Key = key,
                    Value = createdEvent
                };

                await _producer.ProduceAsync(_topic, createdMessage);

                _logger.Debug("{Source} - Ok {@CreatedEvent}", nameof(SendMessageAsync), createdEvent);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "{Source} - Exception {Message}", "ConsumeMessage", ex.Message);
            }
        }
    }
}
