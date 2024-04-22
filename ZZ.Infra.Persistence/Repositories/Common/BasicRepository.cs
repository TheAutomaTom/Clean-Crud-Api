using Microsoft.EntityFrameworkCore;
using ZZ.Core.Application.Interfaces.Persistence;
using ZZ.Infra.Persistence.DbContexts;

namespace ZZ.Infra.Persistence.Repositories.Common
{
  public class BasicRepository<T> : IAsyncRepository<T> where T : class
  {
    protected readonly XXXDbContext _dbContext;

    public BasicRepository(XXXDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public virtual async Task<T> ReadById(int id)
    {
      return await _dbContext.Set<T>().FindAsync(id);
    }

    public virtual async Task<IReadOnlyList<T>> ReadAll()
    {
      return await _dbContext.Set<T>().ToListAsync();
    }

    public virtual async Task<int> Create(T entity)
    {
      _dbContext.Entry(entity).State = EntityState.Added;
      return await _dbContext.SaveChangesAsync();
    }

    public virtual async Task<int> Update(T entity)
    {
      _dbContext.Entry(entity).State = EntityState.Modified;
      return await _dbContext.SaveChangesAsync();
    }

    public virtual async Task<int> Delete(T entity)
    {
      _dbContext.Set<T>().Remove(entity);
      return await _dbContext.SaveChangesAsync();

    }




  }
}
