using MediatR;

namespace DunktonPublicLibrary.App.Application.ChangePassword;

public sealed record ChangePasswordCommand(string Username, string NewPassword, string CurrentPassword) : IRequest<ChangePasswordResponse>;
