using Caticket.SalesAPI.Application.DTOs.Request;
using FluentValidation;

namespace Caticket.SalesAPI.Application.Validators;

public class UserLoginValidator : AbstractValidator<UserLoginRequest> {
    public UserLoginValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("The email field is mandatory.")
            .EmailAddress()
            .WithMessage("The email is invalid, type a valid email format.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("The password field is mandatory.");
    }
}