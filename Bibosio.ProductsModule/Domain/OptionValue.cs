using Bibosio.Abstractions;

namespace Bibosio.ProductsModule.Domain
{
    internal class OptionValue : AppEntity
    {
        internal required string Value { get; set; }

        internal Guid OptionId { get; set; }
        internal Option? Option { get; set; }
    }
}
