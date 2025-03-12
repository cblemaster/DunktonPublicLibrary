
namespace DunktonPublicLibrary.App.Application;

public static class AppConstants
{
    public const string USERNAME_REQUIRED_VALIDATION_ERROR = "Username is required.";
    public const string FIRST_NAME_REQUIRED_VALIDATION_ERROR = "First name is required.";
    public const string LAST_NAME_REQUIRED_VALIDATION_ERROR = "Last name is required.";
    public const string PASSWORD_REQUIRED_VALIDATION_ERROR = "Password is required.";
    public const string NEW_PASSWORD_REQUIRED_VALIDATION_ERROR = "New password is required.";
    public const string CURRENT_PASSWORD_REQUIRED_VALIDATION_ERROR = "Current password is required.";
    public const string NEW_AND_CURRENT_PASSWORDS_SAME_VALIDATION_ERROR = "New and current passwords cannot be the same.";
    public const string ROLE_REQUIRED_VALIDATION_ERROR = "Role is required.";
    public const string ROLE_NOT_FOUND_VALIDATION_ERROR = "Role not found.";
    public const string AUTH_REQUIRED_POLICY_NAME = "requires_auth";

    public static string MaxLengthError(string fieldName, int maxLength) => $"{fieldName} must be {maxLength} characters or fewer.";
    public static string MinLengthError(string fieldName, int minLength) => $"{fieldName} must be at least {minLength} characters.";
}
