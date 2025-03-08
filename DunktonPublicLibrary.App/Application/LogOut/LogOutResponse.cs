
using DunktonPublicLibrary.App.Application;

namespace DunktonPublicLibrary.App.Application.LogOut;

public sealed record LogOutResponse(ResponseType ResponseTypes, string? Message) : ResponseBase(ResponseTypes, Message);
