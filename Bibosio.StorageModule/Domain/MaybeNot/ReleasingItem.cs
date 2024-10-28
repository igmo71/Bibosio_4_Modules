using Bibosio.Abstractions;

namespace Bibosio.StorageModule.Domain.MaybeNot
{
    internal class ReleasingItem : AppEntity
    {
        public Guid ReleasingId { get; set; }
        public Releasing? Releasing { get; set; }

        public Guid StorageItemId { get; set; }
        public StorageItem? StorageItem { get; set; }

        public double Quantity { get; set; }
    }
}
