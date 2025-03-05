
namespace EFCorePractice.App.Domain.Entities;

public sealed class Role : Entity<Role>
{
    public string Name { get; set; } = string.Empty;
    public ICollection<Account> Accounts { get; set; } = [];
    public override Identifer<Role> Id { get; init; }
}
