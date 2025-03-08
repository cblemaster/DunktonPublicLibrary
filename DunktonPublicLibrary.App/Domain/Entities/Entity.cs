namespace DunktonPublicLibrary.App.Domain.Entities;

public abstract class Entity<T>
{
    public abstract Identifer<T> Id { get; init; }
}
