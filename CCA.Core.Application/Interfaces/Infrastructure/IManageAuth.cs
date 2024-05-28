using CCA.Core.Infra.ResultTypes;
using CCA.Core.Infra.Models.Auth.Service;
using CCA.Core.Infra.Models.Auth.Service.RequestDtos.Create;
using CCA.Core.Infra.Models.Auth.Service.ResponseDtos;
using CCA.Core.Infra.Models.Auth.Service.Results;

namespace CCA.Core.Application.Interfaces.Infrastructure
{
	public interface IManageAuth
	{
		Task<Result<User>> CreateUser(UserCreateRequestDto user);
		
		Task<Result<AuthCredential>> AuthenticateUser(string username, string password);



	}
}
