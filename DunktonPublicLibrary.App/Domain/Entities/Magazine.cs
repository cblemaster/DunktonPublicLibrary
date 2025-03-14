
using DunktonPublicLibrary.App.Domain.ValueObjects;

namespace DunktonPublicLibrary.App.Domain.Entities;

public sealed class Magazine : Material<Magazine>
{
    public MagazineInfo MagazineInfo { get; init; }
    public override string Title { get; init; }
    public override Identifer<Material<Magazine>> Id { get; init; }
    public override Identifer<Magazine> ItemId { get; init; }
}
