using System.Linq.Expressions;

namespace CryptoDCA.Infrastructure.Contracts;

public interface IGenericRepository<T> where T : class
{
    Task GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}