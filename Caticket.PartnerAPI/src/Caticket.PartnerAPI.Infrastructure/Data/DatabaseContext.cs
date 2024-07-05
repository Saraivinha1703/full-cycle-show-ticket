using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Infrastructure.Interfaces;
using Caticket.PartnerAPI.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Caticket.PartnerAPI.Infrastructure.Data;

public class DatabaseContext : DbContext { 
    public DatabaseContext() { }   
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder options) {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));
        //running on container
        // var connectionString = "server=partner-db;user=root;password=root;database=api";

        //running locally
        //var connectionString = "server=localhost;user=root;password=root;database=api;port=3307";
        var dbInfo = new DatabaseConnectionInfo();
        
        options.UseMySql(
            dbInfo.ConnectionString, 
            serverVersion, 
            o => o.MigrationsAssembly(dbInfo.Assembly)
        );
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        new EventMap(modelBuilder.Entity<Event>());
        new ReservationHistoryMap(modelBuilder.Entity<ReservationHistory>());
        new SpotMap(modelBuilder.Entity<Spot>());
        new TicketMap(modelBuilder.Entity<Ticket>());
    }
}