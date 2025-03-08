using MediatR;

namespace DunktonPublicLibrary.App.Application.LogIn;

public sealed record LogInCommand : IRequest<LogInResponse>
{

}
