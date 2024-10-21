using Bibosio.CatalogModule.Common;
using Bibosio.CatalogModule.Domain;
using Bibosio.CatalogModule.Interfaces;
using Bibosio.Common.OpenTelemetry;
using Microsoft.Extensions.Logging;
using Serilog;
using SerilogTracing;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Bibosio.CatalogModule.Application
{
    internal class CatalogItemCommandService : ICatalogItemCommandService
    {
        private readonly ICatalogItemRepository _catalogItemRepository;
        
        private readonly ILogger<CatalogItemCommandService> _logger;
        //private readonly ActivitySource _activitySource;
        //private readonly Counter<long> _freezingDaysCounter;

        Serilog.ILogger _serilog;

        public CatalogItemCommandService(
            ICatalogItemRepository catalogItemRepository,
            ILogger<CatalogItemCommandService> logger
            //Instrumentation instrumentation
            )
        {
            _catalogItemRepository = catalogItemRepository;
            _logger = logger;
            //_activitySource = instrumentation.ActivitySource;
            //_freezingDaysCounter = instrumentation.FreezingDaysCounter;

            _serilog = Log.ForContext<CatalogItemCommandService>();
        }

        public async Task<CatalogItem> CreateCatalogItemAsync(CatalogItem catalogItem)
        {
            using var scope = _logger.BeginScope("{Id}", Guid.NewGuid().ToString("N"));

            //using var activity = _activitySource.StartActivity(nameof(CreateCatalogItemAsync));            
            using var activity = _serilog.StartActivity(nameof(CreateCatalogItemAsync));

            await _catalogItemRepository.CreateAsync(catalogItem);

           // _freezingDaysCounter.Add(10);

            _logger.CatalogItemCreatedId(catalogItem.Id.ToString());
            _logger.CatalogItemCreatedObject(catalogItem);

            return catalogItem;
        }
    }
}
