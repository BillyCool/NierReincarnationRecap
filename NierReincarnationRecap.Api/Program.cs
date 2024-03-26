using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NierReincarnationRecap.Business.EF;
using System.Text.Json;
using System.Text.Json.Serialization;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.Configure<JsonSerializerOptions>(x =>
        {
            x.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            x.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            x.PropertyNameCaseInsensitive = true;
        });
        services.AddDbContext<NierReincarnationRecapDbContext>();
    })
    .Build();

host.Run();
