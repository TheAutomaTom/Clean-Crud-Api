using CCA.Core.Infra.Models.Identities;
using CCA.Core.Infra.Models.Responses;
using Mediator;

namespace CCA.Core.Application.Features.Users.CreateUser
{
  public class CreateUserRequest : IRequest<Result>
  {

    public CreateUserRequest(string username, string firstName, string lastName, string email, string password, string role)
    {
      Username = username;
      FirstName = firstName;
      LastName = lastName;
      Email = email;
      Password = password;
			Role = role; // TODO: USe Enum
    }

    public IdentityCreateDto ToDto()
    {
      return new IdentityCreateDto()
      {
        Username = Username,
        FirstName = FirstName,
        LastName = LastName,
        Email = Email,
        Credentials = [new IdentityCredentials(Password)]
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
