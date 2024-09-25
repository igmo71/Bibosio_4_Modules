using Bibosio.Interfaces;
using Bibosio.ProductsModule.Infrastructure.EventBus.Events;

namespace Bibosio.ProductsModule.Infrastructure.EventBus.Kafka
{
    internal class KafkaProductUpdatedProducer : IEventBusProducer<ProductUpdatedEvent>
    {
        public Task SendMessageAsync(string key, ProductUpdatedEvent message)
        {
            throw new NotImplementedException();
        }
    }
}
