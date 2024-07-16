using Microsoft.IdentityModel.Tokens;

namespace Caticket.SalesAPI.Identity.Configurations;

public class JwtOptions {
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    public required SigningCredentials SigningCredentials { get; set; }
    public int Expiration { get; set; }
}