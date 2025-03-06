
using MediatR;

namespace EFCorePractice.App.Application.Register;

public class RegisterHandler : IRequestHandler<RegisterCommand, RegisterResponse>
{
    public Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
