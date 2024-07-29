using Microsoft.Extensions.DependencyInjection;

namespace Caticket.SalesAPI.Core.Services;

public static class ServicesConfiguration {
    /// <summary>
    /// The services configuration and dependency injection is made on the <c>Core</c> layer.
    /// </summary>
    public static void AddCoreServices(this IServiceCollection services) {
        services.AddScoped<EventService>();
        services.AddScoped<SpotService>();
        services.AddScoped<TicketService>();
        services.AddScoped<PartnerService>();
    }
}