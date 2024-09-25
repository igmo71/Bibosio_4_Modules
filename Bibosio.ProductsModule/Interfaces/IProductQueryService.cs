using Bibosio.Interfaces;
using Bibosio.ProductsModule.Domain;
using System.Collections.Immutable;

namespace Bibosio.ProductsModule.Interfaces
{
    internal interface IProductQueryService : IQueryService
    {
        ImmutableList<Product> GetProducts(int? skip = 0, int? top = 100);

        Task<Product> GetProductAsync();
    }
}
