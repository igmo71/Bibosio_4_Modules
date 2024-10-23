using Bibosio.CatalogModule;
using Bibosio.Common.Exceptions;
using Bibosio.Common.OpenTelemetry;
using Bibosio.ProductsModule;
using Bibosio.WeatherForecastModule.Endpoints;
using Bibosio.WebApi.Test;
using Microsoft.AspNetCore.Http.Features;
using Scalar.AspNetCore;
using System.Diagnostics;
using System.Reflection;
//using Serilog;
//using SerilogTracing;

namespace Bibosio.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Serilog
            //builder.Services.AddSerilog(options =>
            //    options.ReadFrom.Configuration(builder.Configuration));
            //
            //using var activityListener = new ActivityListenerConfiguration()
            //    .Instrument.AspNetCoreRequests()
            //    .Instrument.SqlClientCommands()
            //    .Instrument.HttpClientRequests()
            //    .TraceToSharedLogger();
            #endregion

            builder.Logging.ClearProviders();

            var openTelemetryConfig = builder.Configuration.GetSection(OpenTelemetryConfig.Section).Get<OpenTelemetryConfig>()
                ?? throw new ApplicationException("OpenTelemetry configuration not found");
            openTelemetryConfig.Environment = builder.Environment;
            openTelemetryConfig.ServiceVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "unknown";

            builder.Services.ConfigureOpenTelemetry(openTelemetryConfig);

            builder.Services.AddAuthorization();

            builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHealthChecks();

            builder.Services.AddProblemDetails(options =>
            {
                options.CustomizeProblemDetails = context =>
                {
                    context.ProblemDetails.Instance = $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";
                    context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
                    Activity? activity = context.HttpContext.Features.Get<IHttpActivityFeature>()?.Activity;
                    context.ProblemDetails.Extensions.TryAdd("traceId", activity?.Id);
                };
            });
            //builder.Services.AddExceptionHandler<BadRequestExceptionHandler>();
            //builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
            //builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
            builder.Services.AddExceptionHandler<AppExceptionHandler>();

            builder.Services.AddProductsModule(builder.Configuration);
            builder.Services.AddCatalogModule(builder.Configuration);

            builder.Services.AddScoped<ITestService, TestService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
                app.MapScalarApiReference();
            }

            //app.UseSerilogRequestLogging(options => options.IncludeQueryInRequestPath = true);

            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                StatusCodeSelector = ex => ex switch
                {
                    ArgumentException => StatusCodes.Status400BadRequest,
                    AppNotFoundException => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                }
            });
            app.UseStatusCodePages();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseHealthChecks("/healthz");

            app.MapWeatherForecastEndpoint();
            app.MapProductModuleEndpoints();
            app.MapCatalogModuleEndpoints();
            app.MapTestEndpoint();

            app.IfUsePrometheusMetricsExporter(openTelemetryConfig);

            app.Run();
        }
    }
}
