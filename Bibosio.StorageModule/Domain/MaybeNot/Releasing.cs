using Bibosio.Common;

namespace Bibosio.StorageModule.Domain.MaybeNot
{
    internal class Releasing : AppEntity
    {
        public string? Number { get; set; }
        public DateTime DateTime { get; set; }

        public List<ReleasingItem>? Items { get; set; }
    }
}
