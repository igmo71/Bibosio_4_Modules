using Bibosio.ProductsModule.Interfaces;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

namespace Bibosio.ProductsModule.EventBus.Kafka
{
    internal class KafkaProducerService : IEventBusProducer
    {
        private readonly IProducer<string, string> _producer;
        private readonly string _topic;

        public KafkaProducerService(IConfiguration configuration)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"]
            };

            _producer = new ProducerBuilder<string, string>(config).Build();
            _topic = configuration["Kafka:Topic"]
                ?? throw new ApplicationException("Kafka Topic not found");
        }

        public async Task SendMessageAsync(string key, string message)
        {
            var kafkaMessage = new Message<string, string>
            {
                Key = key,
                Value = message
            };

            await _producer.ProduceAsync(_topic, kafkaMessage);
        }
    }
}
