using CCA.Core.Application.Interfaces.Persistence.Common;
using CCA.Core.Domain.Models.Cruds.Repo;
using Nest;
using CCA.Core.Infra.Models.SearchParams;

namespace CCA.Core.Application.Interfaces.Persistence.Cruds
{
  public interface ICrudEntitiesRepository : IEfCoreRepository<CrudEntity>
  { 



  }
}
