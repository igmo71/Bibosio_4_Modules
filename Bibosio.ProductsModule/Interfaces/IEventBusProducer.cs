using Bibosio.ProductsModule.Domain;

namespace Bibosio.ProductsModule.Interfaces
{
    public interface IEventBusProducer<TMessage>
    {
        Task SendMessageAsync(string key, TMessage message);
    }
}
