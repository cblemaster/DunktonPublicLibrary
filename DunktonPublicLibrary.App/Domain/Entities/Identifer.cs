
namespace DunktonPublicLibrary.App.Domain.Entities;

public sealed class Identifer<T>
{
    public Guid Value { get; init; }

    private Identifer(Guid value) => Value = value;

    public static Identifer<T> CreateNewId() => new(Guid.NewGuid());
    public static Identifer<T> CreateFromData(Guid value) => new(value);

    public override bool Equals(object? obj) => obj is Identifer<T> other && Value.Equals(other.Value);
    public static bool operator ==(Identifer<T>? left, Identifer<T>? right) => Equals(left, right);
    public static bool operator !=(Identifer<T>? left, Identifer<T>? right) => !Equals(left, right);
    public override int GetHashCode() => Value.GetHashCode();
}
