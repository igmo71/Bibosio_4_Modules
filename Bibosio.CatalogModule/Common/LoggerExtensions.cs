using Bibosio.CatalogModule.Domain;
using Microsoft.Extensions.Logging;

namespace Bibosio.CatalogModule.Common
{
    public static partial class LoggerExtensions
    {
        [LoggerMessage(
            EventId = 7, 
            Level = LogLevel.Information, 
            Message = "Catalog Item Created with Id `{Id}`")]
        public static partial void CatalogItemCreatedId(
            this ILogger logger, 
            string id);

        // TODO: Add OpenTelemetry
        //[LoggerMessage(
        //    EventId = 8,
        //    Level = LogLevel.Information,
        //    Message = "Catalog Item Created")]
        //internal static partial void CatalogItemCreatedItem(
        //    this ILogger logger,
        //    [LogProperties(OmitReferenceName = true)] in CatalogItem catalogItem);
    }
}
