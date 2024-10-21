using Bibosio.CatalogModule.Domain;
using Microsoft.Extensions.Logging;

namespace Bibosio.CatalogModule.Common
{
    internal static partial class LoggerExtensions
    {
        [LoggerMessage(
            //EventId = 7, 
            Level = LogLevel.Information,
            Message = "Catalog Item Created with Id {Id}")]
        public static partial void CatalogItemCreatedId(
            this ILogger logger, 
            string id);

        [LoggerMessage(
            //EventId = 8,
            Level = LogLevel.Debug,
            Message = "Catalog Item Created")]
        public static partial void CatalogItemCreatedObject(
            this ILogger logger,
            [LogProperties(/*OmitReferenceName = true*/)] in CatalogItem catalogItem);
    }
}
