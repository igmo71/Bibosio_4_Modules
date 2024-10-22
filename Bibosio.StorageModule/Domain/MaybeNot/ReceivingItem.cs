using Bibosio.Common;

namespace Bibosio.StorageModule.Domain.MaybeNot
{
    internal class ReceivingItem : AppEntity
    {
        public Guid ReceivingId { get; set; }
        public Receiving? Receiving { get; set; }

        public Guid StorageItemId { get; set; }
        public StorageItem? StorageItem { get; set; }

        public double Quantity { get; set; }
    }
}
