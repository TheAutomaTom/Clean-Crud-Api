using CCA.Core.Infra.Models.Common;

namespace CCA.Core.Application.Interfaces.Persistence.Common
{
  public interface IEfCoreRepository<T> where T : Auditable
  {
    Task<int> Create(T item);
    Task<int> Delete(int id);
    Task<int> Delete(T item);
    Task<IReadOnlyList<T>> Read();
    Task<T> Read(int id);
    Task<bool> Update(T item);
  }
}