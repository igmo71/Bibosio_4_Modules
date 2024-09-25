using Bibosio.ProductsModule.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Bibosio.ProductsModule.Endpoints
{
    public static class ProductQueryEndpoints
    {
        public static IEndpointRouteBuilder MapProductQueryEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("/api/product")
            .WithTags("Products");

            group.MapGet("/", ([FromQuery] int? skip, [FromQuery] int? top, [FromServices] IProductQueryService productQueryService) =>
            ProductQueryHandler.GetAllProducts(skip, top, productQueryService))
                .WithName("GetAllProducts");

            group.MapGet("/{id}", ProductQueryHandler.GetProductAsync) // TODO: NotImplemented
                .WithName("GetProduct");

            return builder;
        }
    }
}
