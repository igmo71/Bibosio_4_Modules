using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Bibosio.Common.OpenTelemetry
{
    public class Instrumentation : IDisposable
    {
        internal const string ActivitySourceName = $"{nameof(Bibosio)}.ActivitySource";
        internal const string MeterName = $"{nameof(Bibosio)}.Meter";
        private readonly Meter meter;

        public Instrumentation()
        {
            string? version = typeof(Instrumentation).Assembly.GetName().Version?.ToString();
            ActivitySource = new ActivitySource(ActivitySourceName, version);
            meter = new Meter(MeterName, version);
            FreezingDaysCounter = meter.CreateCounter<long>("weather.days.freezing", description: "The number of days where the temperature is below freezing");
        }

        public ActivitySource ActivitySource { get; }

        public Counter<long> FreezingDaysCounter { get; }

        public void Dispose()
        {
            ActivitySource.Dispose();
            meter.Dispose();
        }
    }
}
