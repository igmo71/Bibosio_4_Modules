using Bibosio.Common;
using Bibosio.ProductsModule.Dto;
using Bibosio.ProductsModule.Abstractions;
using Microsoft.Extensions.Logging;

namespace Bibosio.ProductsModule.Application
{
    internal class ProductQueryService : IProductQueryService
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<ProductQueryService> _logger;

        public ProductQueryService(IProductRepository repository, ILogger<ProductQueryService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ProductVm[]> GetProductsAsync(int skip, int top)
        {
            var products = await _repository.GetAllAsync(skip, top);

            var result = products.Select(e => ProductVm.From(e)).ToArray();

            _logger.CouldNotOpenSocket(LogLevel.Error, "localhost");

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
