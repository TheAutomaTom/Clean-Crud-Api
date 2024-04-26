using CCA.Core.Application.Interfaces.Persistence;
using CCA.Core.Domain.Models.Cruds.Repo;
using CCA.Data.Persistence.Repositories.Common;
using CCA.Data.Persistence.Repositories.DbContexts;

namespace CCA.Data.Persistence.Repositories
{
  public class CrudRepository : EFCoreRepository<CrudEntity>, ICrudRepository
  {
    public CrudRepository(CrudContext dbContext) : base(dbContext)
    {

    }






  }
}
