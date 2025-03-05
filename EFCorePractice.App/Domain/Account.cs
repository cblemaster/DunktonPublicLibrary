
namespace EFCorePractice.App.Domain;

public sealed class Account
{
    public Guid Id { get; set; }
    public Role Role { get; set; } = default!;
    public Guid RoleId { get; set; }

    public string? Token { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string PasswordSalt { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => $"{FirstName} {LastName}";
}
