using Bibosio.Abstractions;
using Bibosio.ProductsModule.Dto;

namespace Bibosio.ProductsModule.Abstractions
{
    internal interface IProductQueryService : IQueryService
    {
        Task<ProductVm[]> GetProductsAsync(int skip, int top);

        Task<ProductVm?> GetProductAsync(string id);
    }
}
