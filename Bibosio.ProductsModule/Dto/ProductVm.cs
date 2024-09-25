using Bibosio.ProductsModule.Domain;

namespace Bibosio.ProductsModule.Dto
{
    internal record ProductVm(string Id, string Sku)
    {
        internal static ProductVm From(Product Product)
        {
            return new ProductVm(Product.Id.ToString(), Product.Sku.Value);
        }
    }
}
