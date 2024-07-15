using Caticket.SalesAPI.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Caticket.SalesAPI.Identity.Data;

public class IdentityDataContext : IdentityDbContext<User> {
    public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options) {}
    public IdentityDataContext() {}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "server=localhost;user=root;password=root;database=auth;port=3309";
        //ServerVersion sv = new MySqlServerVersion(new Version(8, 0, 30));

        optionsBuilder.UseMySql(
            connectionString, 
            ServerVersion.AutoDetect(connectionString), 
            msql => msql.MigrationsAssembly("Caticket.SalesAPI.Web")
        );

        base.OnConfiguring(optionsBuilder);
    }
}