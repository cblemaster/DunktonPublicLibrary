
using DunktonPublicLibrary.App.Domain.ValueObjects;

namespace DunktonPublicLibrary.App.Domain.Entities;

public sealed class Book : Material<Book>
{
    public BookInfo BookInfo { get; init; }
    public override Identifer<Book> Id { get; init; }
}
