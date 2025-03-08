
using DunktonPublicLibrary.App.Domain.Entities;

namespace DunktonPublicLibrary.App.Infrastructure;

public sealed class Repository<T>(AppDbContext context) : IRepository<T> where T : Entity<T>
{
    private readonly AppDbContext _context = context;

    public async Task Create(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public T Get(Identifer<T> id) => _context.Set<T>().Find(id.Value);

    public IEnumerable<T> GetAll() => _context.Set<T>();

    public async Task Update(T entity)
    {
        T update = Get(entity.Id);
        // TODO: update entity props (reflection?)
        await _context.SaveChangesAsync();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }
}
