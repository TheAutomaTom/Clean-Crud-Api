using System.Text.Json.Serialization;
using CCA.Core.Infra.Models.Auth.Service.RequestDtos.Create;

namespace CCA.Core.Infra.Models.Auth.Service.RequestDtos.Create
{
	/// <summary> This class is dictated by a Keycloak model. </summary>
	public class UserCreateRequestDto
	{
		public UserCreateRequestDto(string username, string firstName, string lastName, string email, string password)
		{
			Username = username;
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			Credentials = [new UserCredentials(password)];

			// For future enhancements
			EmailVerified = true;
			Enabled = true;

		}

		[JsonPropertyName("username")]
		public string Username { get; set; }

		[JsonPropertyName("firstName")]
		public string FirstName { get; set; }

		[JsonPropertyName("lastName")]
		public string LastName { get; set; }

		[JsonPropertyName("email")]
		public string Email { get; set; }

		[JsonPropertyName("emailVerified")]
		public bool EmailVerified { get; set; }

		[JsonPropertyName("enabled")]
		public bool Enabled { get; set; } = true;

		[JsonPropertyName("credentials")]
		public UserCredentials[] Credentials { get; set; }

	}
}
