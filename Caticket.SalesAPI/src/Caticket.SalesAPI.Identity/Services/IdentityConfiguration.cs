using System.Text;
using Caticket.SalesAPI.Application.Interfaces.Services;
using Caticket.SalesAPI.Identity.Exceptions.JWT;
using Caticket.SalesAPI.Identity.Configurations;
using Caticket.SalesAPI.Identity.Data;
using Caticket.SalesAPI.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Caticket.SalesAPI.Identity.Constants;
using Microsoft.AspNetCore.Builder;

namespace Caticket.SalesAPI.Identity.Services;

public static class IdentityConfiguration {
    /// <summary>
    /// The identity entities and database configuration and dependency injection is made on the <c>Identity</c> layer.
    /// </summary>
    public static void ConfigureIdentity(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<IdentityDataContext>();

        services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<IdentityDataContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<IIdentityService, IdentityService>();

        using IdentityDataContext dbContext = new();
            dbContext.Database.Migrate();

        //JWT config
        IConfigurationSection jwtAppSettingsOptions = configuration.GetSection(nameof(JwtOptions));

        var securityKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(configuration.GetSection("JwtOptions:Key").Value
            ?? throw new JwtConfigurationException("JWT key not found.")));

        string issuer = jwtAppSettingsOptions[nameof(JwtOptions.Issuer)] ?? throw new JwtConfigurationException("Issuer not found.");
        string audience = jwtAppSettingsOptions[nameof(JwtOptions.Audience)] ?? throw new JwtConfigurationException("Audience not found.");
        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha512Signature);
        int expiration = int.Parse(jwtAppSettingsOptions[nameof(JwtOptions.Expiration)] ?? throw new JwtConfigurationException("Expiration time not found"));

        services.Configure<JwtOptions>(options => {
            options.Issuer = issuer;
            options.Audience = audience;
            options.SigningCredentials = signingCredentials;
            options.Expiration = expiration;
        });

        services.Configure<IdentityOptions>(options => {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
        });

        services.AddAuthentication(options => {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options => {
            options.TokenValidationParameters = new() {
                ValidateIssuer = true,
                ValidIssuer = issuer,

                ValidateAudience = true,
                ValidAudience = audience,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero,
            };
        });

        services.AddAuthorization();
    }

    public static void UseIdentity(this WebApplication app) {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}