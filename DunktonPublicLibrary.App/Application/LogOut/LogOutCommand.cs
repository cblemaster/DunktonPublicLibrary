
using MediatR;

namespace DunktonPublicLibrary.App.Application.LogOut;

public sealed record LogOutCommand() : IRequest<LogOutResponse>;
