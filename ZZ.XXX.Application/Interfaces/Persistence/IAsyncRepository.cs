namespace ZZ.XXX.Application.Interfaces.Persistence
{
  public interface IAsyncRepository<T> where T : class
  {
    Task<T> ReadById(int id);
    Task<IReadOnlyList<T>> ReadAll();
    Task<int> Create(T entity);
    Task<int> Update(T entity);
    Task<int> Delete(T entity);


  }
}
