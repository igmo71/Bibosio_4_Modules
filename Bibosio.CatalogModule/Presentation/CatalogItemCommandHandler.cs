using Bibosio.CatalogModule.Domain;
using Bibosio.CatalogModule.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Bibosio.CatalogModule.Presentation
{
    internal static class CatalogItemCommandHandler
    {
        public static async Task<Results<Created<CatalogItem>, BadRequest>> CreateCatalogItemAsync(
            CatalogItem catalogItem, 
            ICatalogItemCommandService service)
        {
            var result = await service.CreateCatalogItemAsync(catalogItem);

            return TypedResults.Created($"/api/catalog/{result.Id}", result);
        }

        public static async Task DeleteCatalogItemAsync(HttpContext context)
        {
            throw new NotImplementedException();
        }

        public static async Task UpdateCatalogItemAsync(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}