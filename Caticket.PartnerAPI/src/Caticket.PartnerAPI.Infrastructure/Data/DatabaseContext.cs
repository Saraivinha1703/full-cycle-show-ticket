using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Caticket.PartnerAPI.Infrastructure.Data;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options) { 
    // public DbSet<Event> Events { get; set; }
    // public DbSet<ReservationHistory> ReservationHistories { get; set; }
    // public DbSet<Spot> Spots { get; set; }
    // public DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        new EventMap(modelBuilder.Entity<Event>());
        new ReservationHistoryMap(modelBuilder.Entity<ReservationHistory>());
        new SpotMap(modelBuilder.Entity<Spot>());
        new TicketMap(modelBuilder.Entity<Ticket>());
    }
}