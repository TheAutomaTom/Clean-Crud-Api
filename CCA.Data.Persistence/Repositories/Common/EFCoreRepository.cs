using CCA.Core.Application.Interfaces.Persistence;
using CCA.Core.Infra.Models.Common;
using CCA.Data.Persistence.Config.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CCA.Data.Persistence.Repositories.Common
{
  public class EFCoreRepository<T> : IAsyncRepository<T> where T : AuditableEntity
  {
    protected readonly CrudContext _dbContext;

    public EFCoreRepository(CrudContext dbContext)
    {
      _dbContext = dbContext;
    }
    
    public virtual async Task<int> Create(T item)
    {
      _dbContext.Entry(item).State = EntityState.Added;
      await _dbContext.SaveChangesAsync();

      return item.Id;
    }

    public virtual async Task<T> Read(int id)
    {
      return await _dbContext.Set<T>().FindAsync(id);
    }

    public virtual async Task<IReadOnlyList<T>> Read()
    {
      return await _dbContext.Set<T>().ToListAsync();
    }

    public virtual async Task<bool> Update(T item)
    {
      _dbContext.Entry(item).State = EntityState.Modified;
      var result = await _dbContext.SaveChangesAsync();
      return result > 0;
    }

    public virtual async Task<int> Delete(T item)
    {
      var entity = _dbContext.Set<T>().Local.FirstOrDefault(entry => entry.Id.Equals(item.Id));

      if (entity == null)
      {
        return 0;
      }

      _dbContext.Remove(entity);
      return await _dbContext.SaveChangesAsync();
    }



    public async Task<int> Delete(int id)
    {
      var entity = _dbContext.Set<T>().Local.FirstOrDefault(entry => entry.Id.Equals(id));

      if (entity == null)
      {
        return 0;
      }

      _dbContext.Remove(entity);
      return await _dbContext.SaveChangesAsync();
    }





  }
}
