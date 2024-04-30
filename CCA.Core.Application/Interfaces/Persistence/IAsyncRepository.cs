using CCA.Core.Domain.Models.Cruds.Repo;
using CCA.Core.Infra.Models.Search;

namespace CCA.Core.Application.Interfaces.Persistence
{
  public interface IAsyncRepository<T> where T : class
  {
    Task<int> Create(T item);
    //Task<IReadOnlyList<T>> Read();
    Task<IReadOnlyList<T>> Read(Paging? paging = null, DateRange? dateRange = null);
    Task<T> Read(int id);
    Task<bool> Update(T item);
    Task<int> Delete(int id);


  }
}
