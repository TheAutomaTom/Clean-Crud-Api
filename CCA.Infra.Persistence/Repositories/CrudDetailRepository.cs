using Nest;
using ZZ.Core.Application.Interfaces.Persistence;
using ZZ.Infra.Persistence.Repositories.Common;
using ZZ.Core.Domain.Models.Cruds.Repo;

namespace ZZ.Infra.Persistence.Repositories
{
  public class CrudDetailRepository : ElasticRepository<CrudDetail>, ICrudDetailRepository
  {

    public CrudDetailRepository(IElasticClient client) : base(client)
    {

    }






  }
}
