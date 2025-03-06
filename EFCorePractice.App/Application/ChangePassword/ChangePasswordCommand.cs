
using MediatR;

namespace EFCorePractice.App.Application.ChangePassword;

public record ChangePasswordCommand : IRequest<ChangePasswordResponse>
{

}
