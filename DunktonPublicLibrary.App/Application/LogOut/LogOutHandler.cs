
using MediatR;

namespace DunktonPublicLibrary.App.Application.LogOut;

public sealed class LogOutHandler : IRequestHandler<LogOutCommand, LogOutResponse>
{
    public async Task<LogOutResponse> Handle(LogOutCommand request, CancellationToken cancellationToken)
    {
        if (!AccountLoggedIn.IsTokenSet)
        {
            return new(ResponseType.UnknownError, null);
        }
        else
        {
            AccountLoggedIn.SetAccount(null);
            return new(ResponseType.Success, null);
        }
    }
}
