using Bibosio.ProductsModule.Domain;
using Bibosio.ProductsModule.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Immutable;

namespace Bibosio.ProductsModule.Endpoints
{
    internal class ProductQueryHandler
    {
        internal static Ok<ImmutableList<Product>> GetAllProducts(int? skip, int? top, IProductQueryService productQueryService)
        {
            ImmutableList<Product> result = productQueryService.GetProducts(skip, top);
            return TypedResults.Ok(result);
        }

        internal static Product GetProductAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
