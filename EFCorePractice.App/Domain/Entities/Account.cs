
using EFCorePractice.App.Cryptography;
using EFCorePractice.App.Domain.ValueObjects;

namespace EFCorePractice.App.Domain.Entities;

public sealed class Account : Entity<Account>
{
    public string? Token { get; set; }
    public Role Role { get; set; } = default!;
    public Identifer<Role> RoleId { get; set; }
    public Credentials Credentials { get; set; }
    public Names Names { get; set; }
    public DateStamps Dates { get; set; }
    public override Identifer<Account> Id { get; init; }

    private Account() { }
    public Account(Role role, Credentials credentials, Names names)
    {
        Role = role;
        RoleId = role.Id;
        Credentials = credentials;
        Names = names;
        Dates = new(DateTime.UtcNow, null);
        Id = Identifer<Account>.CreateNewId();
    }

    public void ChangePassword(PasswordHash hash)
    {
        Credentials = Credentials with { PasswordHash = hash.Hash, PasswordSalt = hash.Salt };
        Dates = Dates with { UpdateDate = DateTime.UtcNow };
    }

    public void LogIn(string? token) => Token = token;

    public void LogOut() { }
}
