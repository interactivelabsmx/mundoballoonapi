using Azure.Monitor.OpenTelemetry.Exporter;
using OpenTelemetry.Trace;

namespace MundoBalloonApi.graphql;

public static class ServicesLoggingExtensions
{
    public static IServiceCollection AddOpenTelemetryLogging(this IServiceCollection services, string connectionString)
    {
        return services.AddOpenTelemetryTracing(builder =>
        {
            builder.AddHttpClientInstrumentation();
            builder.AddAspNetCoreInstrumentation();
            builder.AddHotChocolateInstrumentation();
            builder.AddAzureMonitorTraceExporter(options => { options.ConnectionString = connectionString; });
        });
    }
}