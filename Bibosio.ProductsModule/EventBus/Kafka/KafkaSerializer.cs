using Confluent.Kafka;
using System.Text;
using System.Text.Json;

namespace Bibosio.ProductsModule.EventBus.Kafka
{
    internal class KafkaSerializer<T> : ISerializer<T>
    {
        public byte[] Serialize(T data, SerializationContext context)
        {
            var json = JsonSerializer.Serialize(data);
            var result = Encoding.UTF8.GetBytes(json);
            return result;
        }
    }
}