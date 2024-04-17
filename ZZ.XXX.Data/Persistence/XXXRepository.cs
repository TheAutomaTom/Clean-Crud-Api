using ZZ.XXX.Application.Interfaces.Persistence;
using ZZ.XXX.Domain.Entities;

namespace ZZ.XXX.Data.Persistence
{
  public class XXXRepository : IAsyncRepository<XXXEntity>
  {
    public async Task<XXXEntity> GetByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<XXXEntity>> ListAllAsync()
    {
      throw new NotImplementedException();
    }

    public async Task<XXXEntity> AddAsync(Task entity)
    {
      throw new NotImplementedException();
    }

    public async Task UpdateAsync(Task entity)
    {
      throw new NotImplementedException();
    }

    public async Task DeleteAsync(Task entity)
    {
      throw new NotImplementedException();
    }
  }
}
