using CCA.Core.Domain.Models.Cruds.Repo;
using CCA.Core.Infra.Models.Search;
using CCA.Data.Persistence.Repositories;

namespace CCA.Core.Application.Interfaces.Persistence.Cruds
{
  public interface ICrudEntitiesRepository
  {
    Task<IReadOnlyList<CrudEntity>> Read(Paging paging = null, DateRangeFilter dateRange = null);
  }
}
