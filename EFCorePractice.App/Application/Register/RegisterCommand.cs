
using MediatR;

namespace EFCorePractice.App.Application.Register;

public sealed record RegisterCommand : IRequest<RegisterResponse>
{

}
