
namespace EFCorePractice.App.Application.Register;

public record RegisterResponse(ResponseType ResponseTypes, string Message) : ResponseBase(ResponseTypes, Message);
