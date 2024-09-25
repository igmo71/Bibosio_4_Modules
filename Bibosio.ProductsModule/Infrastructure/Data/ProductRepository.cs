using Bibosio.ProductsModule.Domain;
using Bibosio.ProductsModule.Interfaces;

namespace Bibosio.ProductsModule.Infrastructure.Data
{
    internal class ProductRepository : IProductRepository
    {
        private readonly ProductsDbContext _dbContext;

        public ProductRepository(ProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Product entity)
        {
            _dbContext.Products.Add(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
