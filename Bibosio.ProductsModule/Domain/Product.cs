using Bibosio.Common;
using Bibosio.ProductsModule.Domain.ValueObjects;

namespace Bibosio.ProductsModule.Domain
{
    public class Product : AppEntity
    {
        public Product(Guid id) : base(id)
        {
        }

        public required SKU SKU { get; set; }
        public List<Option>? ProductOptions { get; set; }
    }
}
