
using DunktonPublicLibrary.App.Domain.ValueObjects;

namespace DunktonPublicLibrary.App.Domain.Entities;

public sealed class Book : Material<Book>
{
    public BookInfo BookInfo { get; init; }
    public override Identifer<Material<Book>> Id { get; init; }
    public override Identifer<Book> ItemId { get; init; }
    public override string Title { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
}
