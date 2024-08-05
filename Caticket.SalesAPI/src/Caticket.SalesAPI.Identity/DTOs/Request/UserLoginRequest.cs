namespace Caticket.SalesAPI.Identity.DTOs.Request;

public class UserLoginRequest {
    public required string Email { get; set; }
    public required string Password { get; set; }
}