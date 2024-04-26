using Nest;
using CCA.Core.Application.Interfaces.Persistence;
using CCA.Core.Domain.Models.Cruds.Repo;
using CCA.Data.Persistence.Repositories.Common;

namespace CCA.Data.Persistence.Repositories
{
  public class CrudDetailRepository : ElasticRepository<CrudDetail>, ICrudDetailRepository
  {

    public CrudDetailRepository(IElasticClient client) : base(client)
    {

    }






  }
}
