
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

    public void ChangePassword(PasswordHash hash) => Credentials = Credentials with { PasswordHash = hash.Hash, PasswordSalt = hash.Salt };

    public void LogIn(string? token) => Token = token;

    public void LogOut() { }

    public Account Register() => new();   // TODO:
}
