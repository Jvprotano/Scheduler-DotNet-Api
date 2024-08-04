using Bie.Business.Models;
using FluentValidation;

public class ApplicationUserValidator : AbstractValidator<ApplicationUser>
{
    public ApplicationUserValidator()
    {
        RuleFor(c => c.Email).NotEmpty().WithMessage("Email is required");
    }

    public static void ValidateApplicationUser(ApplicationUser applicationUser)
    {
        var validator = new ApplicationUserValidator();
        var validationResult = validator.Validate(applicationUser);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.ToString());
    }
}
