using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Infrastructure.Interfaces;
using Caticket.PartnerAPI.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Caticket.PartnerAPI.Infrastructure.Data;

public class DatabaseContext : DbContext {        
    public DatabaseContext(IOptions<DatabaseConnectionInfo> dbInfo) { 
        DbInfo = dbInfo.Value; 
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options, IOptions<DatabaseConnectionInfo> dbInfo) : base(options) { 
        DbInfo = dbInfo.Value;
    }

    public DatabaseConnectionInfo DbInfo { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options) {
        options.UseMySql(
            DbInfo.ConnectionString, 
            ServerVersion.AutoDetect(DbInfo.ConnectionString), 
            o => o.MigrationsAssembly(DbInfo.Assembly)
        );
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        _ = new EventMap(modelBuilder.Entity<Event>());
        _ = new ReservationHistoryMap(modelBuilder.Entity<ReservationHistory>());
        _ = new TicketMap(modelBuilder.Entity<Ticket>());
        _ = new SpotMap(modelBuilder.Entity<Spot>());
    }
}