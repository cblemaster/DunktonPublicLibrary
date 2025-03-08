using FluentValidation;

namespace DunktonPublicLibrary.App.Application.ChangePassword;

public sealed class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidator()
    {
        RuleFor(r => r.Username).NotEmpty().WithMessage("Username is required.");
        RuleFor(r => r.Username).MaximumLength(16).WithMessage("Username must be 16 characters or fewer.");

        RuleFor(r => r.NewPassword).NotEmpty().WithMessage("New password is required.");
        RuleFor(r => r.NewPassword).MaximumLength(16).WithMessage("New password must be 16 characters or fewer.");
        RuleFor(r => r.NewPassword).MinimumLength(4).WithMessage("New password must be at least 4 characters.");

        RuleFor(r => r.CurrentPassword).NotEmpty().WithMessage("Current password is required.");
        RuleFor(r => r.CurrentPassword).MaximumLength(16).WithMessage("Current password must be 16 characters or fewer.");
        RuleFor(r => r.CurrentPassword).MinimumLength(4).WithMessage("Current password must be at least 4 characters.");
    }
}
