using MediatR;

namespace DunktonPublicLibrary.App.Application.LogOut;

public sealed class LogOutHandler : IRequestHandler<LogOutCommand, LogOutResponse>
{
    public Task<LogOutResponse> Handle(LogOutCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
