using MediatR;

namespace DunktonPublicLibrary.App.Application.ChangePassword;

public sealed class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, ChangePasswordResponse>
{
    public Task<ChangePasswordResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
