
namespace EFCorePractice.App.Application.LogIn;

public record LogInResponse(ResponseType ResponseTypes, string Message) : ResponseBase(ResponseTypes, Message);
