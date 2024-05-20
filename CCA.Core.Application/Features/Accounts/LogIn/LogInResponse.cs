using CCA.Core.Domain.Models.Accounts;
using CCA.Core.Infra.Models.Users.Results;

namespace CCA.Core.Application.Features.Accounts.LogIn
{
	public class LogInResponse
	{
		public AuthenticationInfo AuthenticationInfo { get; set; }
		public AccountInfo AccountInfo { get; set; }

		public LogInResponse(AuthenticationInfo authenticationInfo, AccountInfo accountInfo)
		{
			AuthenticationInfo = authenticationInfo;
			AccountInfo = accountInfo;
		}



	}
}
