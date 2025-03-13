
namespace DunktonPublicLibrary.App.Domain.Entities;

public sealed class Book : Material<Book>
{
    public string Title { get; init; }
    public string Author { get; init; }
    public string Description { get; init; }
    public string PublicationYear { get; init; }
    public Genre Genre { get; init; }
    public Identifer<Genre> GenreId { get; init; }
    public override Identifer<Book> Id { get; init; }
}
