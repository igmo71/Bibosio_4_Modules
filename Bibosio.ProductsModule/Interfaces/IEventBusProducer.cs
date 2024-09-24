namespace Bibosio.ProductsModule.Interfaces
{
    internal interface IEventBusProducer
    {
        Task SendMessageAsync(string key, string message);
    }
}
