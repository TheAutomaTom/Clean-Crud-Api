using System.Text.Json.Serialization;

namespace CCA.Core.Infra.Models.Users.Results
{
	/// <summary> For receiving a user from Keycloak. </summary>
	public class User
	{
		[JsonPropertyName("id")]
		public string Guid { get; set; }

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


		// TODO: Create long-to-datetime parser

		[JsonPropertyName("createdTimestamp")]
		public long CreatedTimestamp { get; set; }


		[JsonPropertyName("enabled")]
		public bool Enabled { get; set; }

		[JsonPropertyName("totp")]
		public bool Totp { get; set; }

		[JsonPropertyName("notBefore")]
		public int NotBefore { get; set; }


	}
}
