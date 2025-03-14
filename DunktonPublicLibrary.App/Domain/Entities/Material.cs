
namespace DunktonPublicLibrary.App.Domain.Entities;

public abstract class Material : Entity<Material>
{
    public string Title { get; init; }
    public Genre Genre { get; init; }
    public Identifer<Genre> GenreId { get; init; }
    public override Identifer<Material> Id { get; init; }
}
