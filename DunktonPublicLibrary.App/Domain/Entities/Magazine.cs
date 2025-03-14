
using DunktonPublicLibrary.App.Domain.ValueObjects;

namespace DunktonPublicLibrary.App.Domain.Entities;

public sealed class Magazine : Material
{
    public MagazineInfo MagazineInfo { get; init; }
}
