using CCA.Core.Application.Interfaces.Persistence;
using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Domain.Models.Cruds.Repo;

namespace CCA.Core.Application.Interfaces.Persistence
{
  public interface ICrudDetailRepository : IAsyncRepository<CrudDetail>
  {
    Task<IReadOnlyList<Crud>> Read(IEnumerable<CrudEntity> entities);
  }
}
