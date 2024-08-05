using Caticket.SalesAPI.Core.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Caticket.SalesAPI.Core.Services;

public static class ServicesConfiguration {
    /// <summary>
    /// The services configuration and dependency injection is made on the <c>Core</c> layer.
    /// </summary>
    public static void AddCoreServices(this IServiceCollection services, IConfiguration configuration) {
        services.Configure<PartnerInfo>(options => {
            options.BaseURL = configuration.GetSection(nameof(PartnerInfo))[nameof(PartnerInfo.BaseURL)] ?? throw new ApplicationException("Error while trying to get partner service info in app settings");
        });

        services.AddScoped<EventService>();
        services.AddScoped<SpotService>();
        services.AddScoped<TicketService>();
        services.AddScoped<PartnerService>();
    }
}