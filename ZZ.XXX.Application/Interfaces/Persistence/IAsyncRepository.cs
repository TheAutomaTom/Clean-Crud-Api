namespace ZZ.XXX.Application.Interfaces.Persistence
{
  public interface IAsyncRepository<T> where T : class
  {
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> AddAsync(Task entity);
    Task UpdateAsync(Task entity);
    Task DeleteAsync(Task entity);


  }
}
