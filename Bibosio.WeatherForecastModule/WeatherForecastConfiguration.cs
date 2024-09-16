using Bibosio.WeatherForecastModule.Endpoints;
using Microsoft.AspNetCore.Routing;

namespace Bibosio.WeatherForecastModule
{
    public static class WeatherForecastConfiguration
    {
        public static IEndpointRouteBuilder UseWeatherForecastModule(this IEndpointRouteBuilder builder)
        {
            builder.MapWeatherForecastEndpoint();

            return builder;
        }
    }
}
