using Bibosio.Common;

namespace Bibosio.CatalogModule.Domain
{
    internal class OptionValue(Guid id) : AppEntity(id)
    {
        public string? Value { get; set; }

        public Guid OptionId { get; set; }
        public Option? Option { get; set; }
    }
}
