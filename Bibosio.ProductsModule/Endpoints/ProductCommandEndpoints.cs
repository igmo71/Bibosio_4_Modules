using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Bibosio.ProductsModule.Endpoints
{
    internal static class ProductCommandEndpoints
    {
        internal static IEndpointRouteBuilder MapProductCommandEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("/api/products")
                .MapCommandEndpoints()
                .WithTags("Products");

            return builder;
        }

        private static RouteGroupBuilder MapCommandEndpoints(this RouteGroupBuilder group)
        {
            group.MapPost("/", ProductCommandHandler.CreateProductAsync)
                .WithName("CreateProduct");
            group.MapPut("/{id}", ProductCommandHandler.UpdateProductAsync)
                .WithName("UpdateProduct");
            group.MapDelete("/{id}", ProductCommandHandler.DeleteProductAsync)
                .WithName("DeleteProduct");            

            return group;
        }
    }
}
