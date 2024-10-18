using Microsoft.Extensions.Logging;

namespace Bibosio.Common
{
    // TODO: LoggerExtensions Example
    public static partial class LoggerExtensions
    {
        [LoggerMessage(
            EventId = 0,
            //Level = LogLevel.Critical,
            Message = "Could not open socket to `{HostName}`")]
        public static partial void CouldNotOpenSocket(
            this ILogger logger,
            LogLevel level, /* Dynamic log level as parameter, rather than defined in attribute. */
            string hostName);
    }
}
