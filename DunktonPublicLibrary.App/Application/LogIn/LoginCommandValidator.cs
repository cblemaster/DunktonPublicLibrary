
using FluentValidation;

namespace DunktonPublicLibrary.App.Application.LogIn;

public sealed class LoginCommandValidator : AbstractValidator<LogInCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(r => r.Username).NotEmpty().WithMessage(AppConstants.USERNAME_REQUIRED_VALIDATION_ERROR);
        RuleFor(r => r.Username).MaximumLength(DataConstants.USERNAME_MAX_LENGTH).WithMessage(AppConstants.MaxLengthError("{PropertyName}", DataConstants.USERNAME_MAX_LENGTH));

        RuleFor(r => r.Password).NotEmpty().WithMessage(AppConstants.PASSWORD_REQUIRED_VALIDATION_ERROR);
        RuleFor(r => r.Password).MaximumLength(DataConstants.PLAINTEXT_PASSWORD_MAX_LENGTH).WithMessage(AppConstants.MaxLengthError("{PropertyName}", DataConstants.PLAINTEXT_PASSWORD_MAX_LENGTH));
        RuleFor(r => r.Password).MinimumLength(DataConstants.PLAINTEXT_PASSWORD_MIN_LENGTH).WithMessage(AppConstants.MinLengthError("{PropertyName}", DataConstants.PLAINTEXT_PASSWORD_MIN_LENGTH));
    }
}
