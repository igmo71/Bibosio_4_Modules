using Bibosio.Common;

namespace Bibosio.StorageModule.Domain
{
    internal class Transfer : AppEntity
    {
        public DateTime ReceivedAt { get; set; }

        public Guid FromLocationId { get; set; }
        public StorageLocation? FromLocation { get; set; }

        public Guid ToLocationId { get; set; }
        public StorageLocation? ToLocation { get; set; }

        public List<TransferItem>? TransferItems { get; set; }
    }
}
