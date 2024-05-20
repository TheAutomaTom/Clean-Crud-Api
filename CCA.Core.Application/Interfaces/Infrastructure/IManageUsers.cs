using CCA.Core.Infra.ResultTypes;
using CCA.Core.Infra.Models.Users.Requests.Create;
using CCA.Core.Infra.Models.Users.Results;
using CCA.Core.Infra.Models.Users;

namespace CCA.Core.Application.Interfaces.Infrastructure
{
	public interface IManageUsers
	{
		Task<Result<User>> CreateUser(UserCreateRequest user, UserRole role);
		Task<Result<AuthenticationInfo>> AuthenticateUser(string username, string password);



	}
}
