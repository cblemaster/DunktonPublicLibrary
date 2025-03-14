
using DunktonPublicLibrary.App.Domain.Entities;

namespace DunktonPublicLibrary.App.Domain.ValueObjects;

public record struct VideoCassetteInfo(string Director, Genre Genre, string Rating, string ReleaseYear, TimeSpan RunningTime);
