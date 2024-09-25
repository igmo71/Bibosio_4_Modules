using Bibosio.ProductsModule.Domain;
using Bibosio.ProductsModule.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

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

        public ImmutableList<Product> GetAll(int skip, int take)
        {
            var result = _dbContext.Products
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToImmutableList();
            return result;
        }

        public Task<Product> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
