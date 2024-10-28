using Bibosio.Abstractions;
using Bibosio.ProductsModule.Domain.ValueObjects;

namespace Bibosio.ProductsModule.Domain
{
    internal class Product : AppEntity
    {
        internal required Sku Sku { get; set; }

        internal Guid CategoryId { get; set; }
        internal Category? Category { get; set; }

        internal List<ProductOptionValue>? ProductOptions { get; set; }
    }
}
