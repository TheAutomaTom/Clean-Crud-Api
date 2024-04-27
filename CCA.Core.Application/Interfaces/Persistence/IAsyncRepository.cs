namespace CCA.Core.Application.Interfaces.Persistence
{
  public interface IAsyncRepository<T> where T : class
  {
    Task<int> Create(T item);
    Task<IReadOnlyList<T>> Read();
    Task<T> Read(int id);
    Task<bool> Update(T item);
    Task<int> Delete(T item);
    Task<int> Delete(int id);


  }
}
