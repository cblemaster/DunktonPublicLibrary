
namespace DunktonPublicLibrary.App;

public static class DataConstants
{
    public const string USERNAME_COLUMN = "Username";
    public const string PASSWORD_HASH_COLUMN = "PasswordHash";
    public const string PASSWORD_SALT_COLUMN = "PasswordSalt";
    public const string FIRST_NAME_COLUMN = "FirstName";
    public const string LAST_NAME_COLUMN = "LastName";
    public const string CREATE_DATE_COLUMN = "CreateDate";
    public const string UPDATE_DATE_COLUMN = "UpdateDate";

    public const int ROLE_NAME_MAX_LENGTH = 30;
    public const int USERNAME_MAX_LENGTH = 16;
    public const int PASSWORD_HASH_MAX_LENGTH = 255;
    public const int PASSWORD_SALT_MAX_LENGTH = 255;
    public const int FIRST_NAME_MAX_LENGTH = 50;
    public const int LAST_NAME_MAX_LENGTH = 50;
    public const int PLAINTEXT_PASSWORD_MAX_LENGTH = 16;
    public const int PLAINTEXT_PASSWORD_MIN_LENGTH = 4;

    public const bool IS_UNICODE = false;
}
