using Bibosio.CatalogModule.Domain;
using Bibosio.CatalogModule.Infrastructure.Database;
using Bibosio.CatalogModule.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Bibosio.CatalogModule.Endpoints
{
    internal class CatalogItemCommandHandler
    {
        internal static async Task<Results<Created<CatalogItem>, BadRequest>> CreateCatalogItemAsync(
            CatalogItem catalogItem, 
            ICatalogItemCommandService service,
            CatalogDbContext dbContext)
        {
            await dbContext.CatalogItems.AddAsync(catalogItem);
            await dbContext.SaveChangesAsync();
            return TypedResults.Created($"/api/catalog/{catalogItem.Id}", catalogItem);
        }

        internal static async Task DeleteCatalogItemAsync(HttpContext context)
        {
            throw new NotImplementedException();
        }

        internal static async Task UpdateCatalogItemAsync(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}