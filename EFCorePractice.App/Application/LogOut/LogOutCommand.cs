
using MediatR;

namespace EFCorePractice.App.Application.LogOut;

public sealed record LogOutCommand : IRequest<LogOutResponse>
{

}
