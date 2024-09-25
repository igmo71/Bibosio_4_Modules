using Bibosio.ProductsModule.Domain.ValueObjects;

namespace Bibosio.ProductsModule.Infrastructure.EventBus.Events
{
    public record ProductUpdatedEvent(Guid Id, Sku Sku);
}
