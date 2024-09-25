using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Bibosio.ProductsModule.Endpoints
{
    internal static class ProductQueryEndpoints
    {
        public static IEndpointRouteBuilder MapProductQueryEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("/api/products")
                .MapQueryEndpoints()
                .WithName("Products")
                .WithTags("Products");

            return builder;
        }

        private static RouteGroupBuilder MapQueryEndpoints(this RouteGroupBuilder group)
        {            
            group.MapGet("/", ProductQueryHandler.GetAllProductsAsync)
                .WithName("GetAllProducts");
            group.MapGet("/{id}", ProductQueryHandler.GetProductAsync)
                .WithName("GetProduct");

            return group;
        }
    }
}
