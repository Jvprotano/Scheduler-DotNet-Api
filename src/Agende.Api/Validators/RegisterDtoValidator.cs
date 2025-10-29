using Agende.Api.DTOs.Request;
using FluentValidation;

namespace Agende.Api.Validators;

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    private string _passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

    public RegisterDtoValidator()
    {
        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email is required.");

        RuleFor(user => user.FirstName)
            .NotEmpty().WithMessage("First Name is required.");

        RuleFor(user => user.LastName)
            .NotEmpty().WithMessage("Last Name is required.");

        RuleFor(user => user.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Matches(_passwordPattern).WithMessage("Password must be at least 8 characters long and include at least one uppercase letter, one lowercase letter, one number, and one special character.");
    }
}