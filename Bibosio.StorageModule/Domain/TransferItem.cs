namespace Bibosio.StorageModule.Domain
{
    public class TransferItem
    {
        public Guid StorageItemId { get; set; }
        public StorageItem? StorageItem { get; set; }

        public double Quantity { get; set; }
    }
}