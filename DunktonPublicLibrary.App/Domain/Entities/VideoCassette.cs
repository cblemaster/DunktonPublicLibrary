
using DunktonPublicLibrary.App.Domain.ValueObjects;

namespace DunktonPublicLibrary.App.Domain.Entities;

public sealed class VideoCassette : Material
{
    public VideoCassetteInfo VideoCassetteInfo { get; init; }
}
