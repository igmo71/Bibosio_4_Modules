using Bibosio.Interfaces;
using Bibosio.ProductsModule.EventBus.Events;

namespace Bibosio.ProductsModule.EventBus.Kafka
{
    internal class KafkaProductUpdatedProducer : IEventBusProducer<ProductUpdatedEvent>
    {
        public Task SendMessageAsync(string key, ProductUpdatedEvent message)
        {
            throw new NotImplementedException();
        }
    }
}
