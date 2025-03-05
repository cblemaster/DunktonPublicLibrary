
namespace EFCorePractice.App.Domain;

public sealed class Account
{
    public Guid Id { get; set; }
    public Role Role { get; set; } = default!;
}
