using Bibosio.Common;

namespace Bibosio.StorageModule.Domain
{
    internal class ReceivingItem : AppEntity
    {
        public Guid StorageItemId { get; set; }
        public StorageItem? StorageItem { get; set; }

        public Guid StorageLocationId { get; set; }
        public StorageLocation? StorageLocation { get; set; }

        public double Quantity { get; set; }
    }
}
