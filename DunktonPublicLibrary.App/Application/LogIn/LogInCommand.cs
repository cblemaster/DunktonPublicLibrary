
using MediatR;

namespace DunktonPublicLibrary.App.Application.LogIn;

public sealed record LogInCommand(string Username, string Password) : IRequest<LogInResponse>;
