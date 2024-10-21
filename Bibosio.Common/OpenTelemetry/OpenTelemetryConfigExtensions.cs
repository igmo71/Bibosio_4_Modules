using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Exporter;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System.Diagnostics.Metrics;

namespace Bibosio.Common.OpenTelemetry
{
    public static class OpenTelemetryConfigExtensions
    {
        public static IServiceCollection ConfigureOpenTelemetry(this IServiceCollection services, OpenTelemetryConfig oTelConfig)
        {

            services.AddSingleton<Instrumentation>();

            services.AddOpenTelemetry()
                .ConfigureResource(configure =>
                {
                    configure
                        .AddService(
                            serviceName: oTelConfig.Environment.ApplicationName,
                            serviceVersion: oTelConfig.ServiceVersion,
                            serviceInstanceId: Environment.MachineName);
                    configure
                        .AddAttributes(new Dictionary<string, object>
                        {
                            ["deployment.environment"] = oTelConfig.Environment.EnvironmentName
                        });
                })
                .WithLogging(configure =>
                {
                    switch (oTelConfig.LogExporter)
                    {
                        case "otlp":
                            configure.AddOtlpExporter(otlpOptions =>
                            {
                                otlpOptions.Endpoint = new Uri($"{oTelConfig.Otlp.Endpoint}/logs");
                                otlpOptions.Protocol = OtlpExportProtocol.HttpProtobuf;
                                //otlpOptions.Headers = "X-Seq-ApiKey=x4d4zxG37lHw9bSxP74B";
                            });
                            break;
                        default:
                            configure.AddConsoleExporter();
                            break;
                    }
                })
                .WithTracing(configure =>
                {
                    configure
                        .AddSource(Instrumentation.ActivitySourceName)
                        .SetSampler(new AlwaysOnSampler())
                        .AddHttpClientInstrumentation()
                        .AddEntityFrameworkCoreInstrumentation()
                        .AddAspNetCoreInstrumentation(options =>
                        {
                            options.RecordException = oTelConfig.AspNetCoreInstrumentation.RecordException;
                        });
                    // Use IConfiguration binding for AspNetCore instrumentation options.
                    //services.Configure<AspNetCoreTraceInstrumentationOptions>(options =>
                    //    options.RecordException = oTelConfig.AspNetCoreInstrumentation.RecordException);

                    switch (oTelConfig.TracingExporter)
                    {
                        case "zipkin":
                            configure.AddZipkinExporter(options =>
                                {
                                    options.Endpoint = new Uri(oTelConfig.Zipkin.Endpoint);
                                });
                            break;

                        case "otlp":
                            configure.AddOtlpExporter(otlpOptions =>
                            {
                                otlpOptions.Endpoint = new Uri($"{oTelConfig.Otlp.Endpoint}/traces");
                                otlpOptions.Protocol = OtlpExportProtocol.HttpProtobuf;
                                //otlpOptions.Headers = "X-Seq-ApiKey=x4d4zxG37lHw9bSxP74B";
                            });
                            break;

                        default:
                            configure.AddConsoleExporter();
                            break;
                    }
                })
                .WithMetrics(configure =>
                {
                    configure
                        .AddMeter(Instrumentation.MeterName)
                        .SetExemplarFilter(ExemplarFilterType.TraceBased)
                        .AddRuntimeInstrumentation()
                        .AddHttpClientInstrumentation()
                        .AddAspNetCoreInstrumentation();

                    switch (oTelConfig.HistogramAggregation)
                    {
                        case "exponential":
                            configure.AddView(instrument =>
                            {
                                return instrument.GetType().GetGenericTypeDefinition() == typeof(Histogram<>)
                                    ? new Base2ExponentialBucketHistogramConfiguration()
                                    : null;
                            });
                            break;
                        default:
                            // Explicit bounds histogram is the default.
                            // No additional configuration necessary.
                            break;
                    }

                    switch (oTelConfig.MetricsExporter)
                    {
                        case "prometheus":
                            configure.AddPrometheusExporter();
                            break;
                        case "otlp":
                            configure.AddOtlpExporter(otlpOptions =>
                            {
                                otlpOptions.Endpoint = new Uri(oTelConfig.Otlp.Endpoint);
                                otlpOptions.Protocol = OtlpExportProtocol.HttpProtobuf;
                                //otlpOptions.Headers = "X-Seq-ApiKey=x4d4zxG37lHw9bSxP74B";
                            });
                            break;
                        default:
                            configure.AddConsoleExporter();
                            break;
                    }
                });

            return services;
        }

        public static WebApplication IfUsePrometheusMetricsExporter(this WebApplication app, OpenTelemetryConfig oTelConfig)
        {
            // Configure OpenTelemetry Prometheus AspNetCore middleware scrape endpoint if enabled.
            if (oTelConfig.MetricsExporter.Equals("prometheus", StringComparison.OrdinalIgnoreCase))
            {
                app.UseOpenTelemetryPrometheusScrapingEndpoint();
            }
            return app;
        }
    }
}
