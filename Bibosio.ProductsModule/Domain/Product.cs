using Bibosio.Common;
using Bibosio.ProductsModule.Domain.ValueObjects;

namespace Bibosio.ProductsModule.Domain
{
    internal class Product : AppEntity
    {
        public Product(Guid id) : base(id)
        {
        }

        public required Sku Sku { get; set; }
        public List<Option>? ProductOptions { get; set; }
    }
}
