
namespace EFCorePractice.App.Application.ChangePassword;

public record ChangePasswordResponse(ResponseType ResponseType, string Message) : ResponseBase(ResponseType, Message);
