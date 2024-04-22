using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ZZ.Core.Application.Interfaces.Persistence;
using ZZ.Infra.Persistence.EfCore.Common;
using ZZ.Infra.Persistence.EfCore.DbContexts;
using ZZ.Core.Domain.Models.Cruds.Repo;

namespace ZZ.Infra.Persistence.EfCore
{
  public class CrudRepository : EFCoreRepository<CrudEntity>, ICrudRepository
  {
    public CrudRepository(CrudContext dbContext) : base(dbContext)
    {
    
    
    
    }

    



  }
}
