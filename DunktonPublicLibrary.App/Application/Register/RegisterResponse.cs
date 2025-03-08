
namespace DunktonPublicLibrary.App.Application.Register;

public sealed record RegisterResponse(ResponseType ResponseType, string? Message) : ResponseBase(ResponseType, Message);
