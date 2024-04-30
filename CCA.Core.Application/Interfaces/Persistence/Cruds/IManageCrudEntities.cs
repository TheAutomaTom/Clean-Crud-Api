using CCA.Core.Domain.Models.Cruds.Repo;
using CCA.Core.Infra.Models.Search;

namespace CCA.Core.Application.Interfaces.Persistence.Cruds
{
  public interface IManageCrudEntities : IAsyncRepository<CrudEntity>
  {

  }
}
