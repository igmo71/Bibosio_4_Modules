using Bibosio.ProductsModule.Dto;
using Bibosio.ProductsModule.Interfaces;

namespace Bibosio.ProductsModule.Application
{
    internal class ProductQueryService : IProductQueryService
    {
        private readonly IProductRepository _repository;

        public ProductQueryService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductVm[]> GetProductsAsync(int skip, int top)
        {
            var products = await _repository.GetAllAsync(skip, top);

            var result = products.Select(e => ProductVm.From(e)).ToArray();

            return result;
        }

        public async Task<ProductVm?> GetProductAsync(string id)
        {
            var product = await _repository.GetByIdAsync(Guid.Parse(id));

            if (product == null)
                return null;

            var result = ProductVm.From(product);

            return result;
        }
    }
}
