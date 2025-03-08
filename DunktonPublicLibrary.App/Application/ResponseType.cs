
namespace DunktonPublicLibrary.App.Application;

public enum ResponseType
{
    NotSet = 0,
    Success = 1,
    AuthenticationError = 2,
    NotFoundError = 3,
    UnknownError = 4,
    ValidationError = 5,
}
