
using MediatR;

namespace EFCorePractice.App.Application.ChangePassword;

public sealed record ChangePasswordCommand : IRequest<ChangePasswordResponse>
{

}
