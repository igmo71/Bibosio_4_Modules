using Bibosio.ProductsModule.Dto;
using Bibosio.ProductsModule.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Bibosio.ProductsModule.Endpoints
{
    internal class ProductCommandHandler
    {
        public static async Task<Created> CreateProduct(
            [FromBody] CreateProductDto createProductDto,
            [FromServices] IProductCommandServices productCommandService)
        {
            var id = await productCommandService.CreateProduct(createProductDto);

            return TypedResults.Created(id.ToString());
        }
    }
}
