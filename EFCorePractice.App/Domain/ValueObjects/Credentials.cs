
namespace EFCorePractice.App.Domain.ValueObjects;

public record struct Credentials(string? Token, string Username, string PasswordHash, string PasswordSalt);
