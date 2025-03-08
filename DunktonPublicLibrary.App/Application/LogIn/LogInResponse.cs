
using DunktonPublicLibrary.App.Application;

namespace DunktonPublicLibrary.App.Application.LogIn;

public sealed record LogInResponse(ResponseType ResponseType, string? Message) : ResponseBase(ResponseType, Message);
