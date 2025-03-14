
namespace DunktonPublicLibrary.App.Domain.Entities;

public sealed class Genre : Entity<Genre>
{
    public string Name { get; init; }
    public ICollection<VideoCassette> VideoCassettes { get; set; } = [];
    public override Identifer<Genre> Id { get; init; }
}
