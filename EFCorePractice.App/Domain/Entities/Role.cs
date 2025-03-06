
namespace EFCorePractice.App.Domain.Entities;

public sealed class Role : Entity<Role>
{
    public string Name { get; set; } = string.Empty;
    public ICollection<Account> Accounts { get; set; } = [];
    public override Identifer<Role> Id { get; init; } = default!;

    private Role() { }
    private Role(string rolename)
    {
        Name = rolename;
        Id = Identifer<Role>.CreateNewId();
    }

    public static Role CreateForDataSeeding(string rolename) => new(rolename);
}
