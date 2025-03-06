
using MediatR;

namespace EFCorePractice.App.Application.LogOut;

public record LogOutCommand : IRequest<LogOutResponse>
{

}
