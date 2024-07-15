using Microsoft.EntityFrameworkCore;

namespace Caticket.SalesAPI.Infrastructure.Data;

public class DatabaseContext : DbContext
{
     public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}
    public DatabaseContext() {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "server=localhost;user=root;password=root;database=api;port=3308";
        //ServerVersion sv = new MySqlServerVersion(new Version(8, 0, 30));

        optionsBuilder.UseMySql(
            connectionString, 
            ServerVersion.AutoDetect(connectionString), 
            msql => msql.MigrationsAssembly("Caticket.SalesAPI.Web")
        );
        base.OnConfiguring(optionsBuilder);
    }
}
