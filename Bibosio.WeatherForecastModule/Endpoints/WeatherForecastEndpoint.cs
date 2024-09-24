using Bibosio.WeatherForecastModule.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Bibosio.WeatherForecastModule.Endpoints
{
    public static class WeatherForecastEndpoint
    {
        private static readonly string[] _summaries =
                [
                    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
                ];

        public static IEndpointRouteBuilder MapWeatherForecastEndpoint(this IEndpointRouteBuilder builder)
        {

            builder.MapGet("/weatherforecast", (HttpContext httpContext) =>
            {
                WeatherForecast[] forecast = GetForecast();

                Log.ForContext(typeof(WeatherForecastEndpoint)).Debug("{Source} {@WeatherForecast}", nameof(WeatherForecast), forecast);

                return forecast;
            })
            .WithName("GetWeatherForecast");

            builder.MapGet("/weatherforecast2", (HttpContext httpContext, 
                [FromServices] ILogger<WeatherForecast> logger) =>
            {
                WeatherForecast[] forecast = GetForecast();

                logger.LogDebug("ILogger {@WeatherForecast}", forecast);

                return forecast;
            })
            .WithName("GetWeatherForecast_2");

            return builder;
        }

        private static WeatherForecast[] GetForecast()
        {
            var summaries = _summaries;

            var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                })
                .ToArray();
            return forecast;
        }

    }
}
