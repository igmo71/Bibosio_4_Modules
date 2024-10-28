namespace Bibosio.StorageModule.Domain
{
    internal class StorageLocationCapacity
    {
        public Guid StorageLocationId { get; set; }
        public StorageLocation? StorageLocation { get; set; }

        public double MaxCapacity { get; set; }
        public double CurrentCapacity { get; set; }
    }
}
