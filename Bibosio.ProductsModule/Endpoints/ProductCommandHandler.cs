using Bibosio.ProductsModule.Dto;
using Bibosio.ProductsModule.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SerilogTracing;

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

        internal static async Task UpdateProductAsync(
            [FromQuery] string id,
            [FromBody] UpdateProductDto updateProductDto,
            [FromServices] IProductCommandService productCommandService)
        {
            throw new NotImplementedException();
        }

        internal static async Task DeleteProductAsync(
            [FromQuery] string id,
            [FromServices] IProductCommandService productCommandService)
        {
            throw new NotImplementedException();
        }
    }
}
