
namespace EFCorePractice.App.Application.ChangePassword;

public sealed record ChangePasswordResponse(ResponseType ResponseType, string Message) : ResponseBase(ResponseType, Message);
