using Bibosio.CatalogModule.Domain;
using Bibosio.Interfaces;

namespace Bibosio.CatalogModule.Abstractions
{
    internal interface ICatalogItemCommandService : ICommandService
    {
        Task<CatalogItem> CreateCatalogItemAsync(CatalogItem catalogItem);
    }
}