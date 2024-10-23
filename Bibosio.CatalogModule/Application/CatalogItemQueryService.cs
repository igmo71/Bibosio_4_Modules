using Bibosio.CatalogModule.Domain;
using Bibosio.CatalogModule.Interfaces;

namespace Bibosio.CatalogModule.Application
{
    internal class CatalogItemQueryService : ICatalogItemQueryService
    {
        public CatalogItemQueryService()
        {

        }

        public List<CatalogItem> GetParents(CatalogItem catalogItem)
        {
            throw new NotImplementedException();
        }
    }
}
