using Bibosio.CatalogModule.Domain;
using Bibosio.Interfaces;

namespace Bibosio.CatalogModule.Interfaces
{
    internal interface ICatalogItemCommandService : ICommandService
    {
        Task<CatalogItem> CreateCatalogItemAsync(CatalogItem catalogItem);
    }
}