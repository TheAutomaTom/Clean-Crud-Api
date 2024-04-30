using CCA.Core.Application.Interfaces.Persistence.Common;
using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Domain.Models.Cruds.Repo;

namespace CCA.Core.Application.Interfaces.Persistence.Cruds
{
  public interface ICrudDetailsRepository : IElasticRepository<CrudDetail>
  {
    Task<IReadOnlyList<Crud>> Read(IEnumerable<CrudEntity> entities);
    Task<bool> Update(CrudDetail detail);
  }
}
