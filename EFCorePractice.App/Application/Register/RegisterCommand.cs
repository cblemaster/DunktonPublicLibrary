
using MediatR;

namespace EFCorePractice.App.Application.Register;

public record RegisterCommand : IRequest<RegisterResponse>
{

}
