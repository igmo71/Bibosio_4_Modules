using Bibosio.ProductsModule.Dto;

namespace Bibosio.ProductsModule.Interfaces
{
    public interface IProductCommandServices
    {
        Task<Guid> CreateProduct(CreateProductDto createProductDto);
        Task UpdateProduct(UpdateProductDto updateProductDto);
    }
}
