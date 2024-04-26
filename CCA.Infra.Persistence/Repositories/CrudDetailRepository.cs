using Nest;
using CCA.Core.Application.Interfaces.Persistence;
using CCA.Core.Domain.Models.Cruds.Repo;
using CCA.Infra.Persistence.Repositories.Common;

namespace CCA.Infra.Persistence.Repositories
{
  public class CrudDetailRepository : ElasticRepository<CrudDetail>, ICrudDetailRepository
  {

    public CrudDetailRepository(IElasticClient client) : base(client)
    {

    }






  }
}
