using Microsoft.EntityFrameworkCore;
using ZZ.XXX.Application.Interfaces.Persistence;
using ZZ.XXX.Data.DbContexts;
using ZZ.XXX.Domain.Entities;
using ZZ.XXX.Data.Repositories.Common;

namespace ZZ.XXX.Data.Repositories
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
