using Bibosio.ProductsModule.Domain;
using Bibosio.ProductsModule.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Bibosio.ProductsModule.Infrastructure.Database
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

        public async Task<int> UpdateAsync(Product entity)
        {
            _dbContext.Products.Update(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var result = await _dbContext.Products
                .Where(e => e.Id == id)
                .ExecuteDeleteAsync();
            return result;
        }

        public Task<Product[]> GetAllAsync(int skip, int take)
        {
            var result = _dbContext.Products
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToArrayAsync();
            return result;
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            var result = await _dbContext.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return result;
        }
    }
}
