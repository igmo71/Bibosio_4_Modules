using Bibosio.ProductsModule.Domain;
using Bibosio.ProductsModule.Interfaces;

namespace Bibosio.ProductsModule.Infrastructure.Data
{
    internal class ProductRepository : IProductRepository
    {


        public Task<Guid> CreateAsync(Product entity)
        {
            throw new NotImplementedException();
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
