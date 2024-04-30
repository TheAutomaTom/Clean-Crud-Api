using CCA.Core.Infra.Models.Common;
using CCA.Core.Infra.Models.Search;

namespace CCA.Data.Persistence.Repositories.Common
{
  public interface IRepository<T> where T : Auditable
  {
    Task<int> Create(T item);
    Task<T> Read(int id);
    Task<IReadOnlyList<T>> Read();
    Task<bool> Update(T item);
    Task<int> Delete(int id);
    Task<int> Delete(T item);
  }
}