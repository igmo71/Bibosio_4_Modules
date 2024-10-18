using Bibosio.CatalogModule.Domain.Common;

namespace Bibosio.CatalogModule.Domain.ValueObjects
{
    public record Sku(string Value)
    {
        public static Sku From(string? sku) =>
            new(sku
                .AssertNotEmpty()
                .AssertMatchesRegex("[A-Z]{2,4}[0-9]{4,18}"));
    }
}
