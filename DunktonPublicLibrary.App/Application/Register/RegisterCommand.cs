
using MediatR;

namespace DunktonPublicLibrary.App.Application.Register;

public sealed record RegisterCommand(string Username, string FirstName, string LastName, string Password, string Role) : IRequest<RegisterResponse>;
