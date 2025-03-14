﻿
using DunktonPublicLibrary.App.Domain.Entities;

namespace DunktonPublicLibrary.App.Domain.ValueObjects;

public record struct BookInfo(string Author, string Publisher, string Description, string PublicationYear, int PageCount);
