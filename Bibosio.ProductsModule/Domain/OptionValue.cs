using Bibosio.Common;

namespace Bibosio.ProductsModule.Domain
{
    internal class OptionValue(Guid id) : AppEntity(id)
    {
        internal required string Value { get; set; }

        internal Guid OptionId { get; set; }
        internal Option? Option { get; set; }
    }
}
