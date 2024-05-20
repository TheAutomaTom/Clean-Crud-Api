using CCA.Core.Domain.Models.Accounts.Repo;
using CCA.Core.Infra.Models.Users;
using CCA.Core.Infra.Models.Users.Requests.Create;
using CCA.Core.Infra.Models.Users.Results;
using CCA.Core.Infra.ResultTypes;
using Mediator;

namespace CCA.Core.Application.Features.Accounts.CreateAccount.CreateUser
{
	public class CreateUserRequest : IRequest<Result<User>>
	{
		public CreateUserRequest(string username, string firstName, string lastName, string email, string password, string role)
		{
			Username  = username;
			FirstName = firstName;
			LastName  = lastName;
			Email     = email;
			Password  = password;
			Role = role; // TODO: Use Enum
		}

		public CreateUserRequest(CreateAccountRequest request)
		{			
			Username  = request.Username;
			FirstName = request.FirstName;
			LastName  = request.LastName;
			Email     = request.Email;
			Password  = request.Password;
			Role = request.Role; // TODO: Use Enum
		}

		public UserCreateRequest AsKeycloakRequest()
		{
			return new UserCreateRequest()
			{
				Username  = Username,
				FirstName = FirstName,
				LastName  = LastName,
				Email     = Email,
				Credentials = [new UserCredentials(Password)]
			};
		}

		public string Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }

	}
}
