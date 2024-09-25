using Bibosio.Interfaces;
using Bibosio.ProductsModule.Domain.ValueObjects;

namespace Bibosio.ProductsModule.Infrastructure.EventBus.Events
{
    public record ProductCreatedEvent(Guid Id, string Sku) : IEvent;
}
