
namespace DunktonPublicLibrary.App.Domain.Entities;

public sealed class Genre : Entity<Genre>
{
    public string Name { get; init; }
    public override Identifer<Genre> Id { get; init; }
    public ICollection<Material> Materials { get; set; } = [];
}
