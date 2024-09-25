using Bibosio.Interfaces;
using Bibosio.ProductsModule.EventBus.Events;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Bibosio.ProductsModule.EventBus.Kafka
{
    internal class KafkaProductCreatedProducer : IEventBusProducer<ProductCreatedEvent>
    {
        private readonly string _topic;
        private readonly IProducer<string, ProductCreatedEvent> _producer;
        private readonly ILogger<KafkaProductCreatedProducer> _logger;

        public KafkaProductCreatedProducer(ILogger<KafkaProductCreatedProducer> logger, IConfiguration configuration)
        {
            _topic = configuration["Kafka:ProductCreatedTopic"]
                ?? throw new ApplicationException("Kafka ProductCreatedTopic not found");

            var config = new ProducerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"]
            };

            _producer = new ProducerBuilder<string, ProductCreatedEvent>(config)
                .SetValueSerializer(new KafkaSerializer<ProductCreatedEvent>())
                .Build();

            _logger = logger;
        }

        public async Task SendMessageAsync(string key, ProductCreatedEvent createdEvent)
        {
            var createdMessage = new Message<string, ProductCreatedEvent>
            {
                Key = key,
                Value = createdEvent
            };

            await _producer.ProduceAsync(_topic, createdMessage);

            _logger.LogDebug("{Source} {@CreatedEvent}", nameof(SendMessageAsync), createdEvent);
        }
    }
}
