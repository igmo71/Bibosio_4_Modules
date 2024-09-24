
using Bibosio.WeatherForecastModule;
using Serilog;
using SerilogTracing;

namespace Bibosio.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddSerilog(options =>
                options.ReadFrom.Configuration(builder.Configuration));

            using var _ = new ActivityListenerConfiguration()
                .Instrument.AspNetCoreRequests()
                .Instrument.SqlClientCommands()
                .TraceToSharedLogger();

            builder.Services.AddHealthChecks();

            var app = builder.Build();

            app.UseSerilogRequestLogging(options =>
                options.IncludeQueryInRequestPath = true);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseHealthChecks("/healthz");

            app.UseWeatherForecastModule();

            app.Run();
        }
    }
}
