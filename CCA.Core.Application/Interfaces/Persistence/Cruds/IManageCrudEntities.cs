using CCA.Core.Application.Interfaces.Persistence;
using CCA.Core.Domain.Models.Cruds.Repo;
using CCA.Core.Infra.Models.Search;

namespace CCA.Core.Application.Interfaces.Persistence
{
  public interface IManageCrudEntities : IRepository<CrudEntity>
  {

  }
}
