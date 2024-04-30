using CCA.Core.Application.Interfaces.Persistence.Cruds;
using CCA.Core.Domain.Models.Cruds.Repo;
using CCA.Core.Infra.Models.Search;
using CCA.Data.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using CCA.Data.Persistence.Repositories.DbContexts;

namespace CCA.Data.Persistence.Repositories
{
  public class CrudEntitiesRepository : EfCoreRepository<CrudEntity>, ICrudEntitiesRepository
  {
    public CrudEntitiesRepository(GeneralDbContext context) : base(context)
    {

    }


    public async Task<IReadOnlyList<CrudEntity>> Read(Paging paging = default, DateRangeFilter dateRange = default)
    {
      var results = await _dbContext.Set<CrudEntity>()        
        .Take(paging.CountPer)
        .Skip(paging.Skip)
        .Where(c =>
          
          // I initialize ModifiedDate with CreationData in order to make this search more efficient.
          //(c.CreatedDate >= dateRange.From || c.LastModifiedDate >= dateRange.From)
          //&& (c.CreatedDate <= dateRange.Until || c.LastModifiedDate <= dateRange.Until)
          
        (c.LastModifiedDate >= dateRange.From
          && c.LastModifiedDate <= dateRange.Until)
        ).ToListAsync();

      return results;
    }



  }
}
