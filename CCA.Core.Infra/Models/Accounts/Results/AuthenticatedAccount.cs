using System.Text.Json.Serialization;
using CCA.Core.Infra.Models.Accounts.Entities;
using CCA.Core.Infra.Models.Auth.Service.Results;

namespace CCA.Core.Infra.Models.Accounts.Results
{
	public class AuthenticatedAccount
	{
		public AuthenticatedAccount(AuthCredential credential, UserEntity user)
		{
			Credential = credential;
			User = user;
		}

		public AuthCredential Credential { get; set; }
		public UserEntity User { get; set; }



	}
}
