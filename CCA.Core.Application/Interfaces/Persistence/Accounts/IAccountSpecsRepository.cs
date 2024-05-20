using CCA.Core.Application.Interfaces.Persistence.Common;
using CCA.Core.Domain.Models.Accounts.Repo;

namespace CCA.Core.Application.Interfaces.Persistence.Accounts
{
	public interface IAccountSpecsRepository : IEfCoreRepository<AccountSpec>
	{		
		Task<AccountSpec> Read(string guid);


	}
}
