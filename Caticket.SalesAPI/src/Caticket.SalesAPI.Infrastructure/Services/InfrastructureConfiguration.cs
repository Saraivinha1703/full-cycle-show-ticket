using Caticket.SalesAPI.Domain.Entities;
using Caticket.SalesAPI.Domain.Interfaces;
using Caticket.SalesAPI.Infrastructure.Data;
using Caticket.SalesAPI.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Caticket.SalesAPI.Infrastructure.Services;

public static class InfrastructureConfiguration {
    public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration) {
        //db config
        services.AddDbContext<DatabaseContext>();
        
        services.AddScoped<IRepository<Event>, EventRepository>();
        services.AddScoped<IRepository<Spot>, SpotRepository>();
        services.AddScoped<IRepository<Ticket>, TicketRepository>();
    }
}