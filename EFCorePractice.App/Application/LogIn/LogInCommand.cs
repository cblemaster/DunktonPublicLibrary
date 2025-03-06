
using MediatR;

namespace EFCorePractice.App.Application.LogIn;

public record LogInCommand : IRequest<LogInResponse>
{

}
