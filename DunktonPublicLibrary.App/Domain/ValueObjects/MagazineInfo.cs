
using DunktonPublicLibrary.App.Domain.Entities;

namespace DunktonPublicLibrary.App.Domain.ValueObjects;

public record struct MagazineInfo(Category Category, string IssueNumber, string PublicationMonth, string PublicationYear, int PageCount);
