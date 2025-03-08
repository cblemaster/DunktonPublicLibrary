
using DunktonPublicLibrary.App.Domain.Entities;

namespace DunktonPublicLibrary.App.Infrastructure;
public interface IRepository<T> where T : Entity<T>
{
    Task Create(T entity);
    T Get(Identifer<T> id);
    IEnumerable<T> GetAll();
    Task Update(T entity);
    void Delete(T entity);
}