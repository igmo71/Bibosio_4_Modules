using Microsoft.AspNetCore.Hosting;

namespace Bibosio.Common.OpenTelemetry
{
    public class OpenTelemetryConfig
    {
        public const string Section = "OpenTelemetry";

        public required IWebHostEnvironment Environment { get; set; }
        public required string ServiceVersion { get; set; }
        public required string TracingExporter { get; set; }
        public required string MetricsExporter { get; set; }
        public required string LogExporter { get; set; }
        public required string HistogramAggregation { get; set; }
        public required AspNetCoreInstrumentation AspNetCoreInstrumentation { get; set; }
        public required Otlp Otlp { get; set; }
        public required Zipkin Zipkin { get; set; }
    }

    public class AspNetCoreInstrumentation
    {
        public bool RecordException { get; set; }
    }

    public class Otlp
    {
        public required string Endpoint { get; set; }
    }

    public class Zipkin
    {
        public required string Endpoint { get; set; }
    }
}
