using CCA.Core.Infra.EntityUtilities;

namespace CCA.Core.Application.Interfaces.Persistence.Common
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
