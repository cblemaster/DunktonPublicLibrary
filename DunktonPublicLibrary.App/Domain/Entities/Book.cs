
using DunktonPublicLibrary.App.Domain.ValueObjects;

namespace DunktonPublicLibrary.App.Domain.Entities;

public sealed class Book : Material
{
    public BookInfo BookInfo { get; init; }
}
