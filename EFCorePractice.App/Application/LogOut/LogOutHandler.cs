
using MediatR;

namespace EFCorePractice.App.Application.LogOut;

public class LogOutHandler : IRequestHandler<LogOutCommand, LogOutResponse>
{
    public Task<LogOutResponse> Handle(LogOutCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
