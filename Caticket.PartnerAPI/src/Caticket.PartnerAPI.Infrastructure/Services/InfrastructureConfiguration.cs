using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Interfaces;
using Caticket.PartnerAPI.Infrastructure.Data;
using Caticket.PartnerAPI.Infrastructure.Interfaces;
using Caticket.PartnerAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Caticket.PartnerAPI.Infrastructure.Services;

public static class InfrastructureConfiguration {
    /// <summary>
    /// The database configuration and dependency injection is made on the <c>Infrastructure</c> layer.
    /// </summary>
    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration) {
        IConfigurationSection databaseConfigurationSection = configuration.GetSection(nameof(DatabaseConnectionInfo));

        string assembly = databaseConfigurationSection[nameof(DatabaseConnectionInfo.Assembly)] ?? throw new Exception("Error during database assembly configuration");
        string connectionString = databaseConfigurationSection[nameof(DatabaseConnectionInfo.ConnectionString)] ?? throw new Exception("Error during database connection string configuration");

        services.Configure<DatabaseConnectionInfo>(options => {
            options.Assembly = assembly;
            options.ConnectionString = connectionString;
        });

        services.AddDbContext<DatabaseContext>();

        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<ISpotRepository, SpotRepository>();
        services.AddScoped<IRepository<ReservationHistory>, ReservationHistoryRepository>();
        services.AddScoped<IRepository<Ticket>, TicketRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        ServiceProvider serviceProvider = services.BuildServiceProvider();
        using DatabaseContext dbContext = new(serviceProvider.GetRequiredService<IOptions<DatabaseConnectionInfo>>());
        dbContext.Database.Migrate();
    }
}