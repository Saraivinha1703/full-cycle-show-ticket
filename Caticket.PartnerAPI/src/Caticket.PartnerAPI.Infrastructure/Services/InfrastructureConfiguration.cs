using Caticket.PartnerAPI.Core.Entities;
using Caticket.PartnerAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Caticket.PartnerAPI.Infrastructure.Services;

public static class InfrastructureConfiguration {
    public static void Configure(IServiceCollection services) {
        services.AddDbContext<DatabaseContext<Event>>(options => options.UseMySQL());
    }
}