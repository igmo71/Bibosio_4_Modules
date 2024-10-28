using Bibosio.Abstractions;

namespace Bibosio.StorageModule.Domain.MaybeNot
{
    internal class Receiving : AppEntity
    {
        public string? Number { get; set; }
        public DateTime DateTime { get; set; }

        public List<ReceivingItem>? Items { get; set; }
    }
}
