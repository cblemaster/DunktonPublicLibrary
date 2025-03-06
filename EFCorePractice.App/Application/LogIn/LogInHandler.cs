
using MediatR;

namespace EFCorePractice.App.Application.LogIn;

public sealed class LogInHandler : IRequestHandler<LogInCommand, LogInResponse>
{
    public Task<LogInResponse> Handle(LogInCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
