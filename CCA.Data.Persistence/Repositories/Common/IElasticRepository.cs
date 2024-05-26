using CCA.Core.Infra.Models.Common;

namespace CCA.Data.Persistence.Repositories.Common
{
	public interface IElasticRepository<T> : IRepository<T> where T : AuditableEntity
	{
		Task<int> Create(T item);
	}
}
