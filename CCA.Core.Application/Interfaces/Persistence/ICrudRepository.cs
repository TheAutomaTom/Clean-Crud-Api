using CCA.Core.Application.Interfaces.Persistence;
using CCA.Core.Domain.Models.Cruds.Repo;
using CCA.Core.Infra.Models.Search;

namespace CCA.Core.Application.Interfaces.Persistence
{
  public interface ICrudRepository : IAsyncRepository<CrudEntity>
  {
    Task<IReadOnlyList<CrudEntity>> Read(Paging? paging = null, DateRange? dateRange = null);

  }
}
