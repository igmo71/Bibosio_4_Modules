using Bibosio.Abstractions;
using Bibosio.CatalogModule.Domain;

namespace Bibosio.CatalogModule.Abstractions
{
    internal interface ICatalogItemCommandService : ICommandService
    {
        Task<CatalogItem> CreateCatalogItemAsync(CatalogItem catalogItem);
    }
}