
namespace DunktonPublicLibrary.App.Domain.Entities;

public sealed class VideoCassette : Material<VideoCassette>
{
    public string Title { get; init; }
    public string Director { get; init; }
    public string Rating { get; init; }
    public string ReleaseYear { get; init; }
    public Genre Genre { get; init; }
    public Identifer<Genre> GenreId { get; init; }
    public override Identifer<VideoCassette> Id { get; init; }
}
