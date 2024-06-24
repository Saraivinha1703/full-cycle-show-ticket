using Microsoft.Extensions.DependencyInjection;

namespace Caticket.PartnerAPI.Core.Services;

public static class ServicesConfiguration {
    public static void AddCoreServices(this IServiceCollection services) {
        services.AddScoped<EventService>();
        services.AddScoped<SpotService>();
    }
}