namespace ZZ.Core.Application.Interfaces.Persistence
{
  public interface IAsyncRepository<T> where T : class
  {
    Task<int> Create(T item);
    Task<IReadOnlyList<T>> ReadAll();
    Task<T> ReadById(int id);
    Task<int> Update(T item);
    Task<int> Delete(T item);


  }
}
