using DunktonPublicLibrary.App.Application.ChangePassword;
using DunktonPublicLibrary.App.Application.LogIn;
using DunktonPublicLibrary.App.Application.LogOut;
using DunktonPublicLibrary.App.Application.Register;

namespace DunktonPublicLibrary.App.Extensions;

public static class WebAppExtensions
{
    private const string WELCOME_MESSAGE = "Welcome to Dunkton Public Library!";
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapGet("/", () => WELCOME_MESSAGE);
        app.MapChangePasswordEndpoint();
        app.MapLogInEndpoint();
        app.MapLogOutEndpoint();
        app.MapRegisterEndpoint();
    }
}
