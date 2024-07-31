using Caticket.SalesAPI.Identity.Configurations;
using Custom = Caticket.SalesAPI.Identity.Constants;
using Caticket.SalesAPI.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
namespace Caticket.SalesAPI.Identity.Data;

public class IdentityDataContext : IdentityDbContext<User, Role, string> {
    public IdentityDataContext(DbContextOptions<IdentityDataContext> options, IOptions<DatabaseConnectionInfo> dbInfo) : base(options) {
        DbInfo = dbInfo.Value;
    }

    public IdentityDataContext(IOptions<DatabaseConnectionInfo> dbInfo) {
        DbInfo = dbInfo.Value;
    }
    
    public DatabaseConnectionInfo DbInfo { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(
            DbInfo.ConnectionString, 
            ServerVersion.AutoDetect(DbInfo.ConnectionString), 
            msql => msql.MigrationsAssembly(DbInfo.Assembly)
        );
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Role>().HasData(
            new Role(Custom.Roles.Partner) { 
                Id = Guid.NewGuid().ToString() 
            });
        base.OnModelCreating(builder);
    }
}