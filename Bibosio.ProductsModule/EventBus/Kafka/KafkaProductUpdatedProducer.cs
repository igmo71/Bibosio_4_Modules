using Bibosio.Interfaces;
using Bibosio.ProductsModule.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
