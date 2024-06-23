using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Interfaces;
using Caticket.PartnerAPI.Infrastructure.Data;
using Caticket.PartnerAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Caticket.PartnerAPI.Infrastructure.Services;

public static class InfrastructureConfiguration {
    public static void ConfigureDatabase(this IServiceCollection services) {
        services.AddDbContext<DatabaseContext>(options => options.UseMySQL("server=localhost;port=3307;database=api;uid=root;password=root"));

        services.AddScoped<IRepository<Event>, EventRepository>();
        services.AddScoped<IRepository<ReservationHistory>, ReservationHistoryRepository>();
        services.AddScoped<IRepository<Spot>, SpotRepository>();
        services.AddScoped<IRepository<Ticket>, TicketRepository>();
    }
}