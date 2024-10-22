using Bibosio.Common;

namespace Bibosio.StorageModule.Domain
{
    internal class Movement : AppEntity
    {
        public string? Number { get; set; }

        public DateTime DateTime { get; set; }

        public required MovementDirection Direction { get; set; }

        public Guid TypeId { get; set; }
        public MovementType? Type { get; set; }

        public List<MovementItem>? Items { get; set; }

        public string? Discriminator { get; set; }
    }
}
