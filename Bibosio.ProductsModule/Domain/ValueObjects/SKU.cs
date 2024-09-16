using Bibosio.ProductsModule.Domain.Common;

namespace Bibosio.ProductsModule.Domain.ValueObjects
{
    public record SKU(string Value)
    {
        public static SKU From(string? sku) =>
            new(sku
                .AssertNotEmpty()
                .AssertMatchesRegex("[A-Z]{2,4}[0-9]{4,18}"));
    }
}
