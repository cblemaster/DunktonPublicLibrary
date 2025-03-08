
using DunktonPublicLibrary.App.Application;

namespace DunktonPublicLibrary.App.Application.Register;

public sealed record RegisterResponse(ResponseType ResponseTypes, string? Message) : ResponseBase(ResponseTypes, Message);
