using CCA.Core.Application.Interfaces.Persistence;
using CCA.Core.Domain.Models.Cruds.Repo;
using CCA.Core.Infra.Models.Common;
using CCA.Core.Infra.Models.Search;
using CCA.Data.Persistence.Config.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CCA.Data.Persistence.Repositories.Common
{
  public abstract class EFCoreRepository<T> : IAsyncRepository<AuditableEntity>
  {
    protected readonly CrudContext _dbContext;

    public EFCoreRepository(CrudContext dbContext)
    {
      _dbContext = dbContext;
    }
    
    public virtual async Task<int> Create(AuditableEntity item)
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

    public virtual async Task<AuditableEntity> Read(int id)
    {
      return await _dbContext.Set<AuditableEntity>().FindAsync(id);
    }

    public virtual async Task<IReadOnlyList<AuditableEntity>> Read()
    {
      return await _dbContext.Set<AuditableEntity>().ToListAsync();
    }


    public async Task<IReadOnlyList<AuditableEntity>> Read(Paging paging = default, DateRange dateRange = default)
    {
      var results = await _dbContext.Set<AuditableEntity>()
        .Take(paging.CountPer)
        .Where(c =>
          (c.CreatedDate >= dateRange.From || c.LastModifiedDate >= dateRange.From)
          && (c.CreatedDate <= dateRange.Until || c.LastModifiedDate <= dateRange.Until)
        ).ToListAsync();

      return results;
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

    public virtual async Task<bool> Update(AuditableEntity item)
    {
      try
      {
        _dbContext.Entry(item).State = EntityState.Modified;
        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
      } catch (DbUpdateConcurrencyException ex)
      {
        // Ef Core throws when there is no entity to change.
        _dbContext.Entry(item).State = EntityState.Detached;
        //_logger.LogError(ex, $"Failed to update Entity ID# {item.Id}.");
        return false;
      }
    }

    public virtual async Task<int> Delete(AuditableEntity item)
    {
      var entity = _dbContext.Set<AuditableEntity>().Local.FirstOrDefault(entry => entry.Id.Equals(item.Id));

      if (entity == null)
      {
        return 0;
      }

      _dbContext.Remove(entity);
      return await _dbContext.SaveChangesAsync();
    }


  }
}
