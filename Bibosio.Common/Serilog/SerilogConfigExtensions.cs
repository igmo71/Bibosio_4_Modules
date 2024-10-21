using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using SerilogTracing;

namespace Bibosio.Common.Serilog
{
    public static class SerilogConfigExtensions
    {
        public static IServiceCollection ConfigureSerilog(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSerilog(options =>
                options.ReadFrom.Configuration(configuration));

            using var _ = new ActivityListenerConfiguration()
                .Instrument.AspNetCoreRequests()
                .Instrument.SqlClientCommands()
                .TraceToSharedLogger();

            return services;
        }
    }
}
