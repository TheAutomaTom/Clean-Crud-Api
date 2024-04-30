using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Domain.Models.Cruds.Repo;

namespace CCA.Core.Application.Interfaces.Persistence.Cruds
{
  public interface ICrudDetailsRepository
  {
    Task<IReadOnlyList<Crud>> Read(IEnumerable<CrudEntity> entities);
    Task<bool> Update(CrudDetail detail);
  }
}
