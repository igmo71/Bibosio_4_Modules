using Bibosio.Interfaces;
using Bibosio.ProductsModule.Dto;

namespace Bibosio.ProductsModule.Interfaces
{
    internal interface IProductCommandService : ICommandService
    {
        Task<Guid> CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProduct(UpdateProductDto updateProductDto);
    }
}
