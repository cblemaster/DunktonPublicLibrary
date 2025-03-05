namespace EFCorePractice.App.Domain.Entities;

public sealed class Account : Entity<Account>
{
    public Role Role { get; set; } = default!;
    public Guid RoleId { get; set; }

    public string? Token { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string PasswordSalt { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => $"{FirstName} {LastName}";
    public override Identifer<Account> Id { get; init; }
}
