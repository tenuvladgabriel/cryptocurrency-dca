using System.Linq.Expressions;
using CryptoDCA.Core.Entities;
using CryptoDCA.Infrastructure.Context;
using CryptoDCA.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CryptoDCA.Infrastructure;

public class GenericRepository<T>(CryptoDbContext context) : IGenericRepository<T>
    where T : class, IEntity
{
    public Task GetByIdAsync(int id)
        => context.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id);

    public Task<List<T>> GetAllAsync()
        => context.Set<T>().ToListAsync();

    public Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        => context.Set<T>().Where(predicate).ToListAsync();

    public async Task AddAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        context.Set<T>().Update(entity);
        context.SaveChanges();
    }

    public void Delete(T entity)
    {
        context.Set<T>().Remove(entity);
        context.SaveChanges();
    }
}