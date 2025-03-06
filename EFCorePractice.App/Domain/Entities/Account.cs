
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
}
