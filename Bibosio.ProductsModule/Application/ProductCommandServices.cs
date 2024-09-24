using Bibosio.ProductsModule.Dto;
using Bibosio.ProductsModule.Interfaces;
using Serilog;

namespace Bibosio.ProductsModule.Application
{
    public class ProductCommandServices : IProductCommandServices
    {
        public Task<Guid> CreateProduct(CreateProductDto createProductDto)
        {
            var id = Guid.CreateVersion7();

            Log.Debug("{Source} {Id}", nameof(CreateProduct), id);

            return Task.FromResult(id);
        }

        public Task UpdateProduct(UpdateProductDto updateProductDto)
        {
            throw new NotImplementedException();
        }
    }
}
