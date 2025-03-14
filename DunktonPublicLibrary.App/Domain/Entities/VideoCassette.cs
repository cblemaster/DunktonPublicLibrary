
using DunktonPublicLibrary.App.Domain.ValueObjects;

namespace DunktonPublicLibrary.App.Domain.Entities;

public sealed class VideoCassette : Material<VideoCassette>
{
    public VideoCassetteInfo VideoCassetteInfo { get; init; }
    public Genre Genre { get; init; }
    public override string Title { get; init; }
    public override Identifer<Material<VideoCassette>> Id { get; init; }
    public override Identifer<VideoCassette> ItemId { get; init; }
}
