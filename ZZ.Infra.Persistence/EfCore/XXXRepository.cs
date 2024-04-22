using Microsoft.EntityFrameworkCore;
using ZZ.Core.Application.Interfaces.Persistence;
using ZZ.Core.Domain.Entities;
using ZZ.Infra.Persistence.Sql.Common;
using ZZ.Infra.Persistence.Sql.DbContexts;

namespace ZZ.Infra.Persistence.Sql
{
  public class XXXRepository : BasicRepository<XXXEntity>, IXXXRepository
  {
    public XXXRepository(XXXDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<IReadOnlyList<XXXEntity>> ReadAll()
    {
      return await _dbContext.XXXs.ToListAsync();
    }



  }
}
