using Bibosio.ProductsModule.EventBus.Events;
using Bibosio.ProductsModule.Interfaces;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

namespace Bibosio.ProductsModule.EventBus.Kafka
{
    internal class KafkaProductCreatedProducer : IEventBusProducer<ProductCreatedEvent>
    {
        private readonly IProducer<string, ProductCreatedEvent> _producer;
        private readonly string _topic;

        public KafkaProductCreatedProducer(IConfiguration configuration)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"]
            };

            _producer = new ProducerBuilder<string, ProductCreatedEvent>(config)
                .SetValueSerializer(new KafkaSerializer<ProductCreatedEvent>())
                .Build();
            _topic = configuration["Kafka:Topic"]
                ?? throw new ApplicationException("Kafka Topic not found");
        }

        public async Task SendMessageAsync(string key, ProductCreatedEvent message)
        {
            var kafkaMessage = new Message<string, ProductCreatedEvent>
            {
                Key = key,
                Value = message
            };

            await _producer.ProduceAsync(_topic, kafkaMessage);
        }
    }
}
