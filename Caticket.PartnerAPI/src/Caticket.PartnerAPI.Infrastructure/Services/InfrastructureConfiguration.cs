using Caticket.PartnerAPI.Core.Entities;
using Caticket.PartnerAPI.Core.Interfaces;
using Caticket.PartnerAPI.Infrastructure.Data;
using Caticket.PartnerAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Caticket.PartnerAPI.Infrastructure.Services;

public static class InfrastructureConfiguration {
    public static void Configure(IServiceCollection services) {
        //TODO: Implement generic dbContext, preferred to add a Program.cs file in the Infrastructure, so the migrations and anything related to the database only happens here.
        services.AddDbContext<DatabaseContext<object>>(options => options.UseMySQL("server=localhost;port=3307;database=api;uid=root;password=root"));

        services.AddScoped<IRepository<Event>, EventRepository>();
        services.AddScoped<IRepository<ReservationHistory>, ReservationHistoryRepository>();
        services.AddScoped<IRepository<Spot>, SpotRepository>();
        services.AddScoped<IRepository<Ticket>, TicketRepository>();
    }
}