using Bibosio.ProductsModule.Domain;

namespace Bibosio.ProductsModule.Dto
{
    internal record ProductVm(string Id, string Sku)
    {
        internal static ProductVm From(Product product)
        {
            return new ProductVm(product.Id.ToString(), product.Sku.Value);
        }
    }
}
