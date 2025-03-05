
using EFCorePractice.App.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=.;Database=EFCorePractice;Trusted_Connection=true;Trust Server Certificate=true"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
