using FluentValidation;

namespace DunktonPublicLibrary.App.Application.Register;

public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(r => r.Username).NotEmpty().WithMessage("Username is required.");
        RuleFor(r => r.Username).MaximumLength(16).WithMessage("Username must be 16 characters or fewer.");

        RuleFor(r => r.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(r => r.FirstName).MaximumLength(50).WithMessage("First name must be 50 characters or fewer.");

        RuleFor(r => r.LastName).NotEmpty().WithMessage("Last name is required.");
        RuleFor(r => r.LastName).MaximumLength(50).WithMessage("Last name must be 50 characters or fewer.");

        RuleFor(r => r.Role).NotEmpty().WithMessage("Role is required.");

        RuleFor(r => r.Password).NotEmpty().WithMessage("Password is required.");
        RuleFor(r => r.Password).MaximumLength(16).WithMessage("Password must be 16 characters or fewer.");
        RuleFor(r => r.Password).MinimumLength(4).WithMessage("Password must be at least 4 characters.");
    }
}
