using Bibosio.CatalogModule.Common;
using Bibosio.CatalogModule.Domain;
using Bibosio.CatalogModule.Infrastructure.Database;
using Bibosio.CatalogModule.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;

namespace Bibosio.CatalogModule.Presentation
{
    internal class CatalogItemCommandHandler
    {
        internal static async Task<Results<Created<CatalogItem>, BadRequest>> CreateCatalogItemAsync(
            CatalogItem catalogItem, 
            ICatalogItemCommandService service,
            CatalogDbContext dbContext,
            ILogger<CatalogItemCommandHandler> logger)
        {
            await dbContext.CatalogItems.AddAsync(catalogItem);
            await dbContext.SaveChangesAsync();
            
            logger.CatalogItemCreatedId(catalogItem.Id.ToString());
            logger.CatalogItemCreatedItem(catalogItem);


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