
namespace EFCorePractice.App.Application.Register;

public sealed record RegisterResponse(ResponseType ResponseTypes, string Message) : ResponseBase(ResponseTypes, Message);
