using Bibosio.Common;

namespace Bibosio.ProductsModule.Domain
{
    internal class Category : AppEntity
    {
        internal required string Name { get; set; }
        internal bool IsUseInProductName { get; set; }

        internal Guid? ParentId { get; set; }
        internal Category? Parent { get; set; }

        internal List<Category>? Children { get; set; }

        internal List<Option>? Options { get; set; }

        internal List<Product>? Products { get; set; }
    }
}
