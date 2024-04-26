using Bogus;
using Microsoft.EntityFrameworkCore;
using CCA.Core.Application.Interfaces.Persistence;
using CCA.Core.Domain.Models.Cruds.Repo;
using CCA.Infra.Persistence.Repositories.Common;
using CCA.Infra.Persistence.Repositories.DbContexts;

namespace CCA.Infra.Persistence.Repositories
{
  public class CrudRepository : EFCoreRepository<CrudEntity>, ICrudRepository
  {
    public CrudRepository(CrudContext dbContext) : base(dbContext)
    {

    }






  }
}
