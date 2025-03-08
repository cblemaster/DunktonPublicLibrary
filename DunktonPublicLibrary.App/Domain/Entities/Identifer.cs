
namespace DunktonPublicLibrary.App.Domain.Entities;

public sealed class Identifer<T>
{
    public Guid Value { get; init; }

    private Identifer(Guid value) => Value = value;

    public static Identifer<T> CreateNewId() => new(Guid.NewGuid());
    public static Identifer<T> CreateFromData(Guid value) => new(value);
}
