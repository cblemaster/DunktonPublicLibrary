
namespace EFCorePractice.App.Domain.ValueObjects;

public record struct Credentials(string Username, string PasswordHash, string PasswordSalt);
