namespace Caticket.SalesAPI.Application.DTOs.Request;

public class UserSignUpRequest {
    public required string Email { get; set; }
    public required string Name { get; set; }
    public required string Password { get; set; }
    public required string ConfirmPassword { get; set; }
}