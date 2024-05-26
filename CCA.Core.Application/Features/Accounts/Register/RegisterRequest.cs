using CCA.Core.Infra.ResultTypes;
using Mediator;
using CCA.Core.Infra.Models.Auth.Service;
using CCA.Core.Infra.Models.Auth.Service.RequestDtos.Create;
using CCA.Core.Infra.Models.Emails;
using CCA.Core.Infra.Models.Accounts.Results;

namespace CCA.Core.Application.Features.Accounts.CreateAccount
{
	public class RegisterRequest : IRequest<Result<AuthenticatedAccount>>
	{
		public RegisterRequest(string username, string firstName, string lastName, string email, string password, UserRole role)
		{
			Username = username;
			Email = email;
			FirstName = firstName;
			LastName = lastName;
			Password = password;
			Role = role; // TODO: Use Enum
		}

		public RegisterRequest(){ }

		public string Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public UserRole Role { get; set; }

		

	}



}
