
namespace DunktonPublicLibrary.App.Domain.Entities;

public abstract class Material<T> : Entity<T>
{
    public string Title { get; init; }
    public Genre Genre { get; init; }
    public Identifer<Genre> GenreId { get; init; }
    public override Identifer<T> Id { get; init; }
}
