using Bibosio.Common;
using Bibosio.ProductsModule.Domain.ValueObjects;

namespace Bibosio.ProductsModule.Domain
{
    public class Product : AppEntity
    {
        public required SKU SKU { get; set; }
        public List<Option>? ProductOptions { get; set; }
    }
}
