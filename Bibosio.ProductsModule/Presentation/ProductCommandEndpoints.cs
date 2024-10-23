using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Bibosio.ProductsModule.Presentation
{
    internal static class ProductCommandEndpoints
    {
        public static IEndpointRouteBuilder MapProductCommandEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("/api/product")
                .WithTags("Products");

            group.MapPost("/", ProductCommandHandler.CreateProductAsync)
                .WithName("CreateProduct");

            group.MapPut("/", ProductCommandHandler.UpdateProductAsync)
                .WithName("UpdateProduct");

            group.MapDelete("/{id}", ProductCommandHandler.DeleteProductAsync)
                .WithName("DeleteProduct");

            return builder;
        }
    }
}
