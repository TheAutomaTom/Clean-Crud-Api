using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCA.Core.Infra.Models.Common;
using CCA.Core.Infra.Models.Search;
using Microsoft.EntityFrameworkCore;
using CCA.Data.Persistence.Repositories.DbContexts;

namespace CCA.Data.Persistence.Repositories.Common
{
  public abstract class EfCoreRepository<T> : IRepository<T> where T : Auditable
  {
    protected readonly GeneralDbContext _dbContext;

    protected EfCoreRepository(GeneralDbContext context)
    {
      _dbContext = context;
    }

    public virtual async Task<int> Create(T item)
    {
      try
      {
        _dbContext.Entry(item).State = EntityState.Added;
        await _dbContext.SaveChangesAsync();
        return item.Id;
      }
      catch (DbUpdateConcurrencyException ex)
      {
        _dbContext.Entry(item).State = EntityState.Detached;
        return 0;
      }

    }

    public virtual async Task<T> Read(int id)
    {
      return await _dbContext.Set<T>().FindAsync(id);
    }

    public virtual async Task<IReadOnlyList<T>> Read()
    {
      return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<int> Delete(int id)
    {
      var entity = await _dbContext.Cruds.FindAsync(id);
      if (entity == null)
      {
        return 0;
      }

      _dbContext.Cruds.Remove(entity);
      return await _dbContext.SaveChangesAsync();
    }

    public virtual async Task<bool> Update(T item)
    {
      try
      {
        _dbContext.Entry(item).State = EntityState.Modified;
        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
      }
      catch (DbUpdateConcurrencyException ex)
      {
        // Ef Core throws when there is no entity to change.
        _dbContext.Entry(item).State = EntityState.Detached;
        //_logger.LogError(ex, $"Failed to update Entity ID# {item.Id}.");
        return false;
      }
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


  }
}
