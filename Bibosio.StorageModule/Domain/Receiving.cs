using Bibosio.Common;

namespace Bibosio.StorageModule.Domain
{
    internal class Receiving : AppEntity
    {
        public DateTime ReceivedAt { get; set; }

        public List<ReceivingItem>? ReceivingItems { get; set; }
    }
}
