using Bogus;
using Microsoft.EntityFrameworkCore;
using ZZ.Core.Application.Interfaces.Persistence;
using ZZ.Core.Domain.Models.Cruds.Repo;
using ZZ.Infra.Persistence.Repositories.Common;
using ZZ.Infra.Persistence.Repositories.DbContexts;

namespace ZZ.Infra.Persistence.Repositories
{
  public class CrudRepository : EFCoreRepository<CrudEntity>, ICrudRepository
  {
    public CrudRepository(CrudContext dbContext) : base(dbContext)
    {

    }






  }
}
