using Microsoft.EntityFrameworkCore;
using ZZ.XXX.Application.Interfaces.Persistence;
using ZZ.XXX.Data.Persistence.Common;
using ZZ.XXX.Domain.Entities;
using ZZ.XXX.Data.DbContexts;

namespace ZZ.XXX.Data.Persistence
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
