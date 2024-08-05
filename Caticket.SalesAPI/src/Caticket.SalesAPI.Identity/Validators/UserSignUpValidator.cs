using Caticket.SalesAPI.Identity.DTOs.Request;
using FluentValidation;

namespace Caticket.SalesAPI.Application.Validators;

public class UserSignUpValidator : AbstractValidator<UserSignUpRequest> {
    public UserSignUpValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("The email field is mandatory.")
            .EmailAddress()
            .WithMessage("The email is invalid, type a valid email format.");
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("The name field is mandatory.");
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("The password field is mandatory.")
            .MinimumLength(6)
            .WithMessage("The password must have more than 6 digits.")
            .MaximumLength(55)
            .WithMessage("The password must have less than 55 digits.")
            .Must(s => s.Any(char.IsUpper))
            .WithMessage("The password must have upper case letter.")
            .Must(s => s.Any(char.IsLower))
            .WithMessage("The password must have lower case letter.")
            .Must(s => s.Any(c => !char.IsLetterOrDigit(c)))
            .WithMessage("The password must have a special character.");

        RuleFor(x => x.ConfirmPassword)
            .Matches(y => y.Password)
            .WithMessage("The confirm password must match the password field.");
    }
}