using Bibosio.Common;

namespace Bibosio.StorageModule.Domain
{
    internal class StorageLocation : AppEntity
    {
        public required string Code { get; set; }
        public StorageLocationType? LocationType { get; set; }
        public StorageLocationCapacity? LocationCapacity { get; set; }

        public Guid? ParentLocationId { get; set; }
        public StorageLocation? ParentLocation { get; set; }

        public List<StorageLocation>? ChildLocations { get; set; }

        public string FullCode
        {
            get
            {
                string? result = null;

                List<StorageLocation>? parents = GetParents();

                if (parents != null && parents.Count > 0)
                {
                    foreach (var parent in parents)
                    {
                        result = $"{parent.Code}-";
                    }
                }
                return $"{result}{Code}";
            }
        }

        // TODO: GetParents Not Implemented
        private List<StorageLocation>? GetParents()
        {
            throw new NotImplementedException();
        }
    }
}
