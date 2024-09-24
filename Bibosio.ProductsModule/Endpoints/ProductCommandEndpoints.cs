using Bibosio.ProductsModule.Dto;
using Bibosio.ProductsModule.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Bibosio.ProductsModule.Endpoints
{
    public static class ProductCommandEndpoints
    {
        public static IEndpointRouteBuilder MapProductCommandEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("/api/products")
                .MapProductApi()
                .WithName("Products")
                .WithTags("Products");

            return builder;
        }

        public static RouteGroupBuilder MapProductApi(this RouteGroupBuilder group)
        {
            group.MapPost("/", ProductCommandHandler.CreateProduct);
            //group.MapPut("/{id}", UpdateTodo);
            //group.MapDelete("/{id}", DeleteTodo);
            //group.MapGet("/", GetAllTodos);
            //group.MapGet("/{id}", GetTodo);

            return group;
        }
    }
}
