
namespace DunktonPublicLibrary.App.Application.LogOut;

public sealed record LogOutResponse(ResponseType ResponseType, string? Message) : ResponseBase(ResponseType, Message);
