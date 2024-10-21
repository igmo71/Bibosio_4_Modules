using Bibosio.CatalogModule.Domain;
using Bibosio.CatalogModule.Interfaces;
    
namespace Bibosio.CatalogModule.Infrastructure.Database
{
    internal class CatalogItemRepository : ICatalogItemRepository
    {
        private readonly CatalogDbContext _dbContext;

        public CatalogItemRepository(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(CatalogItem entity)
        {
            await _dbContext.CatalogItems.AddAsync(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CatalogItem[]> GetAllAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<CatalogItem?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(CatalogItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
