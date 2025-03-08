
using DunktonPublicLibrary.App.Application;

namespace DunktonPublicLibrary.App.Application.LogIn;

public sealed record LogInResponse(ResponseType ResponseTypes, string? Message) : ResponseBase(ResponseTypes, Message);
