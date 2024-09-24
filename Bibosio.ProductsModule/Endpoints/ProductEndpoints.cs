using Bibosio.ProductsModule.Dto;
using Bibosio.ProductsModule.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Bibosio.ProductsModule.Endpoints
{
    public static class ProductEndpoints
    {
        public static RouteGroupBuilder MapProductEndpoints(this RouteGroupBuilder builder)
        {
            var group = builder.MapGroup("/api/products")
                .MapProductApi()
                .WithName("Name - Products")
                .WithTags("product", "create", "update");

            return builder;
        }

        public static RouteGroupBuilder MapProductApi(this RouteGroupBuilder group)
        {
            group.MapPost("/", CreateProduct);
            //group.MapGet("/", GetAllTodos);
            //group.MapGet("/{id}", GetTodo);
            //group.MapPut("/{id}", UpdateTodo);
            //group.MapDelete("/{id}", DeleteTodo);

            return group;
        }

        public static async Task<Created> CreateProduct(
            [FromBody] CreateProductDto createProductDto,
            [FromServices] IProductCommandServices productCommandService)
        {
            var id = await productCommandService.CreateProduct(createProductDto);

            return TypedResults.Created(id.ToString());
        }
    }
}
