using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Interfaces;
using Caticket.PartnerAPI.Infrastructure.Data;
using Caticket.PartnerAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Caticket.PartnerAPI.Infrastructure.Services;

public static class InfrastructureConfiguration {
    public static void ConfigureDatabase(this IServiceCollection services) {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));
        var connectionString = "server=localhost;user=root;password=root;database=api;port=3307";
        
        services.AddDbContext<DatabaseContext>(
            options => options.UseMySql(
                connectionString, 
                serverVersion, 
                o => o.MigrationsAssembly("Caticket.PartnerAPI.Web")
            )
        );

        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IRepository<ReservationHistory>, ReservationHistoryRepository>();
        services.AddScoped<IRepository<Spot>, SpotRepository>();
        services.AddScoped<IRepository<Ticket>, TicketRepository>();
    }
}