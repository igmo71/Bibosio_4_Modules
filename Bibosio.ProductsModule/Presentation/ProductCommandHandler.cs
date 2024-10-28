﻿using Bibosio.ProductsModule.Dto;
using Bibosio.ProductsModule.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Bibosio.ProductsModule.Presentation
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

        public static async Task<NoContent> UpdateProductAsync(
            [FromBody] UpdateProductDto updateProductDto,
            [FromServices] IProductCommandService productCommandService)
        {
            await productCommandService.UpdateProductAsync(updateProductDto);

            return TypedResults.NoContent();
        }

        public static async Task<NoContent> DeleteProductAsync(
            [FromQuery] string id,
            [FromServices] IProductCommandService productCommandService)
        {
            await productCommandService.DeleteProductAsync(id);

            return TypedResults.NoContent();
        }
    }
}
