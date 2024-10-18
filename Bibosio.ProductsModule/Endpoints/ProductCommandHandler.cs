using Bibosio.ProductsModule.Dto;
using Bibosio.ProductsModule.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Bibosio.ProductsModule.Endpoints
{
    internal class ProductCommandHandler
    {
        public static async Task<Created> CreateProductAsync(
            [FromBody] CreateProductDto createProductDto,
            [FromServices] IProductCommandService productCommandService)
        {
            var id = await productCommandService.CreateProductAsync(createProductDto);

            return TypedResults.Created(id.ToString());
        }

        internal static async Task<NoContent> UpdateProductAsync(
            [FromBody] UpdateProductDto updateProductDto,
            [FromServices] IProductCommandService productCommandService)
        {
            await productCommandService.UpdateProductAsync(updateProductDto);

            return TypedResults.NoContent();
        }

        internal static async Task<NoContent> DeleteProductAsync(
            [FromQuery] string id,
            [FromServices] IProductCommandService productCommandService)
        {
            await productCommandService.DeleteProductAsync(id);

            return TypedResults.NoContent();
        }
    }
}
