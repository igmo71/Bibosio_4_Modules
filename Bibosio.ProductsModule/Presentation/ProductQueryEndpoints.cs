using Bibosio.ProductsModule.Dto;
using Bibosio.ProductsModule.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Bibosio.ProductsModule.Presentation
{
    public static class ProductQueryEndpoints
    {
        public static IEndpointRouteBuilder MapProductQueryEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("/api/product")
            .WithTags("Products");

            group.MapGet("/", async Task<Results<Ok<ProductVm[]>, ProblemHttpResult>> (
                [FromServices] IProductQueryService productQueryService,
                [FromQuery] int skip = 0,
                [FromQuery] int top = 100) =>
            {
                var result = await productQueryService.GetProductsAsync(skip, top);
                return TypedResults.Ok(result);
            }).WithName("GetAllProducts");

            group.MapGet("/{id}", async Task<Results<Ok<ProductVm>, NotFound>> (
                [FromServices] IProductQueryService productQueryService,
                [FromRoute] string id) =>
            {
                var result = await productQueryService.GetProductAsync(id);
                return result == null
                    ? TypedResults.NotFound()
                    : TypedResults.Ok(result);
            })
                .WithName("GetProduct");

            return builder;
        }
    }
}
