using CCA.Core.Application.Features.Accounts.CreateAccount.CreateUser;
using CCA.Core.Domain.Models.Accounts;
using CCA.Core.Infra.ResultTypes;
using Mediator;

namespace CCA.Core.Application.Features.Accounts.CreateAccount
{
	public class CreateAccountRequest : IRequest<Result<AccountInfo>>
	{
		public CreateAccountRequest(string username, string firstName, string lastName, string email, string password, string role)
		{
			Username = username;
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			Password = password;
			Role = role; // TODO: Use Enum
		}

		public string Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }

		

	}
}
