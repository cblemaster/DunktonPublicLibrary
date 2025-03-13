
using DunktonPublicLibrary.App.Domain.ValueObjects;

namespace DunktonPublicLibrary.App.Domain.Entities;

public sealed class Magazine : Material<Magazine>
{
    public MagazineInfo MagazineInfo { get; init; }
    public override Identifer<Magazine> Id { get; init; }
}
