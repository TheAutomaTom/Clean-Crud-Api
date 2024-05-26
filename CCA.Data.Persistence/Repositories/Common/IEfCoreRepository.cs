using CCA.Core.Infra.Models.Common;

namespace CCA.Data.Persistence.Repositories.Common
{
	public interface IEfCoreRepository<T> : IRepository<T> where T : AuditableEntity
	{
		Task<T> Create(T item);
	}
}
