using Bibosio.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibosio.StorageModule.Domain
{
    internal class StorageLocation : AppEntity
    {
        public required string Code { get; set; }
        public LocationType? LocationType { get; set; }

        public double MaxCapacity { get; set; }
        public double CurrentCapacity { get; set; }

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

        private List<StorageLocation>? GetParents()
        {
            throw new NotImplementedException();
        }
    }
}
