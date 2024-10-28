using Bibosio.Abstractions;

namespace Bibosio.StorageModule.Domain
{
    internal class MovementItem : AppEntity
    {
        public Guid MovementId { get; set; }
        public Movement? Movement { get; set; }


        public Guid StorageItemId { get; set; }
        public StorageItem? StorageItem { get; set; }

        public double Quantity { get; set; }
    }
}