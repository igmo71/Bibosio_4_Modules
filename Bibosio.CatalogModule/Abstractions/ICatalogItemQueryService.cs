using Bibosio.CatalogModule.Domain;
using Bibosio.Interfaces;

namespace Bibosio.CatalogModule.Abstractions
{
    internal interface ICatalogItemQueryService : IQueryService
    {
        List<CatalogItem> GetParents(CatalogItem catalogItem);
    }
}
