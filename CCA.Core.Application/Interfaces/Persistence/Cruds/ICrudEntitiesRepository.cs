using CCA.Core.Application.Interfaces.Persistence.Common;
using CCA.Core.Domain.Models.Cruds.Repo;
using CCA.Core.Infra.Models.Search;
using Nest;

namespace CCA.Core.Application.Interfaces.Persistence.Cruds
{
  public interface ICrudEntitiesRepository : IEfCoreRepository<CrudEntity>
  { 
    Task<IReadOnlyList<CrudEntity>> Read(Paging paging = null, DateRangeFilter dateRange = null);
  }
}
