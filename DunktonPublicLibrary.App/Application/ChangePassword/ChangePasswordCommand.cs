using MediatR;

namespace DunktonPublicLibrary.App.Application.ChangePassword;

public sealed record ChangePasswordCommand : IRequest<ChangePasswordResponse>
{

}
