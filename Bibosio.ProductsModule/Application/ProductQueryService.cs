using Bibosio.ProductsModule.Domain;
using Bibosio.ProductsModule.Interfaces;
using System.Collections.Immutable;

namespace Bibosio.ProductsModule.Application
{
    internal class ProductQueryService : IProductQueryService
    {
        private readonly IProductRepository _repository;

        public ProductQueryService(IProductRepository repository)
        {
            _repository = repository;
        }

        public ImmutableList<Product> GetProducts(int? skip = 0, int? top = 100)
        {
            var result = _repository.GetAll((int)skip!, (int)top!);
            return result;
        }

        public Task<Product> GetProductAsync()
        {
            throw new NotImplementedException();
        }
    }
}
