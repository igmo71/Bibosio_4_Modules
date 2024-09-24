using Bibosio.Interfaces;
using Bibosio.ProductsModule.Domain.ValueObjects;

namespace Bibosio.ProductsModule.EventBus.Events
{
    public record ProductCreatedEvent(Guid Id, SKU SKU) : IEvent;
}
