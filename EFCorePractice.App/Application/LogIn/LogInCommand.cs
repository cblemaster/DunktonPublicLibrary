
using MediatR;

namespace EFCorePractice.App.Application.LogIn;

public sealed record LogInCommand : IRequest<LogInResponse>
{

}
