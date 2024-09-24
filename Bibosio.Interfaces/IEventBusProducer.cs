namespace Bibosio.Interfaces
{
    public interface IEventBusProducer<TMessage>
    {
        Task SendMessageAsync(string key, TMessage message);
    }
}
