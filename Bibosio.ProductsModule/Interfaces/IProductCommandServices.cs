using Bibosio.ProductsModule.Dto;

namespace Bibosio.ProductsModule.Interfaces
{
    internal interface IProductCommandServices
    {
        Task<Guid> CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProduct(UpdateProductDto updateProductDto);
    }
}
