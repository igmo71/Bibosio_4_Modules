using Bibosio.Common;

namespace Bibosio.StorageModule.Domain
{
    internal class Stock : AppEntity
    {
        public Guid StorageLocationId { get; set; }
        public StorageLocation? StorageLocation { get; set; }

        public Guid StorageItemId { get; set; }
        public StorageItem? StorageItem { get; set; }

        public double Quantity { get; set; }
    }
}
