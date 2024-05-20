using CCA.Core.Infra.EntityUtilities;
using CCA.Core.Infra.Models.SearchParams;

namespace CCA.Core.Application.Interfaces.Persistence.Common
{
	public interface IEfCoreRepository<T> where T : Auditable
  {
    Task<T> Create(T item);
    Task<IReadOnlyList<T>> Read();
		Task<IReadOnlyList<T>> Read(Paging paging = null, DateRangeFilter dateRange = null);
    Task<T> Read(int id);
		Task<bool> Update(T item);
    Task<int> Delete(T item);
    Task<int> Delete(int id);
  }
}