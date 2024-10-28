using Bibosio.CatalogModule.Common;
using Bibosio.CatalogModule.Domain;
using Bibosio.CatalogModule.Abstractions;
using Bibosio.Common.OpenTelemetry;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Diagnostics.Metrics;
//using Serilog;
//using SerilogTracing;

namespace Bibosio.CatalogModule.Application
{
    internal class CatalogItemCommandServiceDecorator : ICatalogItemCommandService
    {
        private readonly CatalogItemCommandService _commandService;

        private readonly ILogger<CatalogItemCommandService> _logger;
        private readonly ActivitySource _activitySource;
        private readonly Counter<long> _catalogItemCreatedCounter;

        public CatalogItemCommandServiceDecorator(
            CatalogItemCommandService commandService,
            ILogger<CatalogItemCommandService> logger,
            Instrumentation instrumentation)
        {
            _commandService = commandService;
            _logger = logger;
            _activitySource = instrumentation.ActivitySource;
            _catalogItemCreatedCounter = instrumentation.CatalogItemCreatedCounter;

            //_serilog = Log.ForContext<CatalogItemCommandService>();
        }

        public async Task<CatalogItem> CreateCatalogItemAsync(CatalogItem catalogItem)
        {
            //using var scope = _logger.BeginScope("{Id}", Guid.NewGuid().ToString("N"));
            using var scope = _logger.BeginScope("{Source} {SourceMethod}", nameof(CatalogItemCommandService), nameof(CreateCatalogItemAsync));

            //using var activity = _serilog.StartActivity(nameof(CreateCatalogItemAsync));
            //using var activity = Log.Logger.ForContext<CatalogItemCommandService>().StartActivity(nameof(CreateCatalogItemAsync));
            using var activity = _activitySource.StartActivity(nameof(CreateCatalogItemAsync));

            var result = await _commandService.CreateCatalogItemAsync(catalogItem);

            _catalogItemCreatedCounter.Add(1);

            _logger.CatalogItemCreatedId(catalogItem.Id.ToString());
            _logger.CatalogItemCreatedObject(catalogItem);

            return result;
        }
    }
}
