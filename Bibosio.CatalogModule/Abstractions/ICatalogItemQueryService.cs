using Bibosio.Abstractions;
using Bibosio.CatalogModule.Domain;

namespace Bibosio.CatalogModule.Abstractions
{
    internal interface ICatalogItemQueryService : IQueryService
    {
        List<CatalogItem> GetParents(CatalogItem catalogItem);
    }
}
