
namespace EFCorePractice.App.Domain.Entities;

public abstract class Entity<T>
{
    public abstract Identifer<T> Identifer { get; init; }
}
