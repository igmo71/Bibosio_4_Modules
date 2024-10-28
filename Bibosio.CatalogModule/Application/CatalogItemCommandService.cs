using Bibosio.CatalogModule.Domain;
using Bibosio.CatalogModule.Abstractions;

namespace Bibosio.CatalogModule.Application
{
    internal class CatalogItemCommandService : ICatalogItemCommandService
    {
        private readonly ICatalogItemRepository _catalogItemRepository;

        public CatalogItemCommandService(ICatalogItemRepository catalogItemRepository)
        {
            _catalogItemRepository = catalogItemRepository;
        }

        public async Task<CatalogItem> CreateCatalogItemAsync(CatalogItem catalogItem)
        {
            await _catalogItemRepository.CreateAsync(catalogItem);

            CatalogItem vvv = new CatalogItem();

            return catalogItem;
        }
    }
}
