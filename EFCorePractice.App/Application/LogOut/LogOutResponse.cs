
namespace EFCorePractice.App.Application.LogOut;

public record LogOutResponse(ResponseType ResponseTypes, string Message) : ResponseBase(ResponseTypes, Message);
