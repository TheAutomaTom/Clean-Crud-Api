using CCA.Core.Application.Interfaces.Persistence.Common;
using CCA.Core.Infra.Models.Accounts.Entities;

namespace CCA.Core.Application.Interfaces.Persistence.Accounts
{
	public interface IAccountSpecsRepository : IEfCoreRepository<UserEntity>
	{		
		Task<UserEntity> Read(string guid);


	}
}
