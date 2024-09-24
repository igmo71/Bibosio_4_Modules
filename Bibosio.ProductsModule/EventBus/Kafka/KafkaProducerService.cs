using Bibosio.ProductsModule.Domain;
using Bibosio.ProductsModule.Interfaces;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

namespace Bibosio.ProductsModule.EventBus.Kafka
{
    internal class KafkaProducerService : IEventBusProducer<Product>
    {
        private readonly IProducer<string, Product> _producer;
        private readonly string _topic;

        public KafkaProducerService(IConfiguration configuration)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"]
            };

            _producer = new ProducerBuilder<string, Product>(config)
                .SetValueSerializer(new KafkaSerializer<Product>())
                .Build();
            _topic = configuration["Kafka:Topic"]
                ?? throw new ApplicationException("Kafka Topic not found");
        }

        public async Task SendMessageAsync(string key, Product message)
        {
            var kafkaMessage = new Message<string, Product>
            {
                Key = key,
                Value = message
            };

            await _producer.ProduceAsync(_topic, kafkaMessage);
        }
    }
}
