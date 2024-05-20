using CCA.Core.Infra.ResultTypes;
using CCA.Core.Infra.Models.Users.Requests.Create;
using CCA.Core.Infra.Models.Users.Results;

namespace CCA.Core.Application.Interfaces.Infrastructure
{
	public interface IManageUsers
	{
		Task<Result<User>> CreateUser(UserCreateRequest user, string role);
		Task<Result<AuthenticationInfo>> AuthenticateUser(string username, string password);



	}
}
