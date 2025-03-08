namespace DunktonPublicLibrary.App.Domain.ValueObjects;

public record struct Names(string FirstName, string LastName)
{
    public readonly string FullName => $"{FirstName} {LastName}";
}
