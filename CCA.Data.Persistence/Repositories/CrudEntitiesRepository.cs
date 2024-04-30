using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCA.Core.Domain.Models.Cruds.Repo;
using CCA.Core.Infra.Models.Search;
using CCA.Data.Persistence.Config.DbContexts;
using CCA.Data.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using CCA.Core.Application.Interfaces.Persistence.Cruds;

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
        .Where(c =>
          (c.CreatedDate >= dateRange.From || c.LastModifiedDate >= dateRange.From)
          && (c.CreatedDate <= dateRange.Until || c.LastModifiedDate <= dateRange.Until)
        ).ToListAsync();

      return results;
    }



  }
}
