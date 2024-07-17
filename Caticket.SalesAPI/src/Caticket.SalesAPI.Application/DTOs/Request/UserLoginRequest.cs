namespace Caticket.SalesAPI.Application.DTOs.Request;

public class UserLoginRequest {
    public required string Email { get; set; }
    public required string Password { get; set; }
}