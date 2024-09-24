using Bibosio.ProductsModule.Domain.ValueObjects;

namespace Bibosio.ProductsModule.EventBus.Events
{
    public record ProductUpdatedEvent(Guid Id, Sku Sku);
}
