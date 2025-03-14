
namespace DunktonPublicLibrary.App.Domain.Entities;

public sealed class Category : Entity<Category>
{
    public string Name { get; init; }
    //public ICollection<Material> Materials { get; set; } = [];
    public override Identifer<Category> Id { get; init; }
}
