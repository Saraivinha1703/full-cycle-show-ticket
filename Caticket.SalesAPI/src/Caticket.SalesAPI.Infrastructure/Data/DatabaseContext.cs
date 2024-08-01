using Microsoft.EntityFrameworkCore;

namespace Caticket.SalesAPI.Infrastructure.Data;

public class DatabaseContext : DbContext
{
     public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}
    public DatabaseContext() {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //string connectionString = "server=localhost;user=root;password=root;database=api;port=3306";
        string connectionString = "server=sales-db;user=root;password=root;database=api;port=3306";

        optionsBuilder.UseMySql(
            connectionString, 
            ServerVersion.AutoDetect(connectionString), 
            msql => msql.MigrationsAssembly("Caticket.SalesAPI.Web")
        );
        base.OnConfiguring(optionsBuilder);
    }
}
