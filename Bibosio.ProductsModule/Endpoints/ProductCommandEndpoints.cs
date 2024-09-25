using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Bibosio.ProductsModule.Endpoints
{
    public static class ProductCommandEndpoints
    {
        public static IEndpointRouteBuilder MapProductCommandEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("/api/product")
                .WithTags("Products");

            group.MapPost("/", ProductCommandHandler.CreateProductAsync)
                .WithName("CreateProduct");

            group.MapPut("/{id}", ProductCommandHandler.UpdateProductAsync) // TODO: NotImplemented
                .WithName("UpdateProduct");

            group.MapDelete("/{id}", ProductCommandHandler.DeleteProductAsync) // TODO: NotImplemented
                .WithName("DeleteProduct");

            return builder;
        }
    }
}
