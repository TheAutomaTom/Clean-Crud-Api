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
		public CreateUserRequest(string username, string firstName, string lastName, string email, string password, UserRole role)
		{
			Username  = username;
			Email     = email;
			FirstName = firstName;
			LastName  = lastName;
			Password  = password;
			Role = role; 
		}

		public CreateUserRequest(CreateAccountRequest request)
		{			
			Username  = request.Username;
			Email     = request.Email;
			Password  = request.Password;
			FirstName = request.FirstName;
			LastName  = request.LastName;
			Role = request.Role;
		}

		public UserCreateRequest AsKeycloakRequest()
		{
			return new UserCreateRequest()
			{
				Username  = Username,
				Email     = Email,
				FirstName = FirstName,
				LastName  = LastName,
				Credentials = [new UserCredentials(Password)]
			};
		}

		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public UserRole Role { get; set; }

	}
}
