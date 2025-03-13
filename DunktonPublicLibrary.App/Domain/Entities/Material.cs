
namespace DunktonPublicLibrary.App.Domain.Entities;

public abstract class Material<T> : Entity<T>
{
    public override Identifer<T> Id { get; init; }
}
