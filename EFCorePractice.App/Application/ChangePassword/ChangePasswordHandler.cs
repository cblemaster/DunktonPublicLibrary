
using MediatR;

namespace EFCorePractice.App.Application.ChangePassword;

public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, ChangePasswordResponse>
{
    public Task<ChangePasswordResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
