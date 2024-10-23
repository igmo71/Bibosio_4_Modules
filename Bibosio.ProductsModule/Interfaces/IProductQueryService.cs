using Bibosio.Interfaces;
using Bibosio.ProductsModule.Dto;

namespace Bibosio.ProductsModule.Interfaces
{
    internal interface IProductQueryService : IQueryService
    {
        Task<ProductVm[]> GetProductsAsync(int skip, int top);

        Task<ProductVm?> GetProductAsync(string id);
    }
}
