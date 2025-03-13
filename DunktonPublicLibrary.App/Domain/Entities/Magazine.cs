
namespace DunktonPublicLibrary.App.Domain.Entities;

public sealed class Magazine : Material<Magazine>
{
    public string Title { get; init; }
    public string IssueNumber { get; init; }
    public string PublicationMonth { get; init; }
    public string PublicationYear { get; init; }
    public Genre Genre { get; init; }
    public Identifer<Genre> GenreId { get; init; }

    public override Identifer<Magazine> Id { get; init; }
}
