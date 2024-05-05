using Npgsql;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Ilse.Start.Api.Config;

internal partial class Config
{
    public static IOpenTelemetryBuilder AddTelemetry(IServiceCollection services)
    {
        return services
            .AddOpenTelemetry()
            .ConfigureResource(r => r.AddService("Inventory"))
            .WithTracing(t =>
            {
                t.AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddNpgsql()
                    .AddOtlpExporter();
            });
    }
}
