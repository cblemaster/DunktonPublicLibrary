
using DunktonPublicLibrary.App.Domain.ValueObjects;

namespace DunktonPublicLibrary.App.Domain.Entities;

public sealed class VideoCassette : Material<VideoCassette>
{
    public VideoCassetteInfo VideoCassetteInfo { get; init; }
    public override Identifer<VideoCassette> Id { get; init; }
}
