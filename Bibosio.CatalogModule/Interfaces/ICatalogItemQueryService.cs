using Bibosio.CatalogModule.Domain;
using Bibosio.Interfaces;

namespace Bibosio.CatalogModule.Interfaces
{
    internal interface ICatalogItemQueryService : IQueryService
    {
        List<CatalogItem> GetParents(CatalogItem catalogItem);
    }
}
