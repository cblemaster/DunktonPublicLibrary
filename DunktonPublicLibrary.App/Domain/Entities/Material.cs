
namespace DunktonPublicLibrary.App.Domain.Entities;

public abstract class Material<T> : Entity<Material<T>>
{
    public abstract string Title { get; init; }
    public abstract override Identifer<Material<T>> Id { get; init; }
    public abstract Identifer<T> ItemId { get; init; }
}
