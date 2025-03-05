namespace EFCorePractice.App.Domain.Entities;

public sealed class Role
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Account> Accounts { get; set; } = [];
}
