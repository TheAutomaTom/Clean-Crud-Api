using CCA.Core.Infra.EntityUtilities;

namespace CCA.Data.Persistence.Repositories.Common
{
	public interface IEfCoreRepository<T> : IRepository<T> where T : Auditable
	{
		Task<T> Create(T item);
	}
}
