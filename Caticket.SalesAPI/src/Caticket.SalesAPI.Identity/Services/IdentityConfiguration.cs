using Caticket.SalesAPI.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Caticket.SalesAPI.Identity.Services;

public static class IdentityConfiguration {
    /// <summary>
    /// The identity entities and database configuration and dependency injection is made on the <c>Identity</c> layer.
    /// </summary>
    public static void ConfigureIdentity(this IServiceCollection services) {
        services.AddDbContext<IdentityDataContext>();

        using IdentityDataContext dbContext = new();
        dbContext.Database.Migrate();
    }
}