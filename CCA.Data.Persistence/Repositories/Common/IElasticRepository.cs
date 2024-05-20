using CCA.Core.Infra.EntityUtilities;

namespace CCA.Data.Persistence.Repositories.Common
{
	public interface IElasticRepository<T> : IRepository<T> where T : Auditable
	{
		Task<int> Create(T item);
	}
}
