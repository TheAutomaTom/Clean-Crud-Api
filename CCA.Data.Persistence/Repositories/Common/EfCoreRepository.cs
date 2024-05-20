using CCA.Core.Infra.EntityUtilities;
using CCA.Core.Infra.Models.SearchParams;
using CCA.Data.Persistence.Config.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CCA.Data.Persistence.Repositories.Common
{
	public abstract class EfCoreRepository<T> : IEfCoreRepository<T> where T : Auditable
  {
    protected readonly GeneralDbContext _dbContext;

    protected EfCoreRepository(GeneralDbContext context)
    {
      _dbContext = context;
    }

    public virtual async Task<T> Create(T item)
    {
      try
      {
        _dbContext.Entry(item).State = EntityState.Added;
        await _dbContext.SaveChangesAsync();
        return item;
      }
      catch (DbUpdateConcurrencyException ex)
      {
        _dbContext.Entry(item).State = EntityState.Detached;
        return null;
      }
			catch (Exception ex)
			{
				throw;
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

		public async Task<IReadOnlyList<T>> Read(Paging paging = default, DateRangeFilter dateRange = default)
		{
			var results = await _dbContext.Set<T>()
				.Take(paging.CountPer)
				.Skip(paging.Skip)
				.Where(c =>

				// I initialize ModifiedDate with CreationData in order to make this search more efficient.
				//(c.CreatedDate >= dateRange.From || c.LastModifiedDate >= dateRange.From)
				//&& (c.CreatedDate <= dateRange.Until || c.LastModifiedDate <= dateRange.Until)

				c.LastModifiedDate >= dateRange.From
					&& c.LastModifiedDate <= dateRange.Until
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
