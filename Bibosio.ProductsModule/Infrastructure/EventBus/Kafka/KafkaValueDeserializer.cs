using Confluent.Kafka;
using System.Text.Json;

namespace Bibosio.ProductsModule.Infrastructure.EventBus.Kafka
{
    internal class KafkaValueDeserializer<T> : IDeserializer<T>
    {
        public T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            T result = JsonSerializer.Deserialize<T>(data)
                ?? throw new ApplicationException("Failed to deserialize");

            return result;
        }
    }
}
