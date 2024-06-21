using Microsoft.EntityFrameworkCore;

namespace Caticket.PartnerAPI.Infrastructure.Data;

public class DatabaseContext<T>(DbContextOptions<DatabaseContext<T>> options) : DbContext(options) where T : class {
    public DbSet<T> Entity {get; set;}
}