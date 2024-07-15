using System.ComponentModel.DataAnnotations;

namespace Caticket.SalesAPI.Application.DTOs.Request;

public class UserLoginRequest {
    [Required(ErrorMessage = "The field {0} is mandatory.")]
    [EmailAddress(ErrorMessage = "The field {0} is invalid, type a valid email.")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "The field {0} is mandatory.")]
    [StringLength(50, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 6)]
    public required string Password { get; set; }
}