using System.Text.Json.Serialization;

namespace CCA.Core.Infra.Models.Identities
{
  /// <summary> This class is dictated by a Keycloak model. </summary>
  public class IdentityCreateDto
  {
    [JsonPropertyName("username")]
    public string Username {get; set;}

    [JsonPropertyName("firstName")]
    public string FirstName {get; set;}

    [JsonPropertyName("lastName")]
    public string LastName {get; set;}

    [JsonPropertyName("email")]
    public string Email {get; set;}

    [JsonPropertyName("emailVerified")]
    public bool   EmailVerified { get; set;}

		[JsonPropertyName("enabled")]
		public bool Enabled { get; set; } = true;

    [JsonPropertyName("credentials")]
    public IdentityCredentials[] Credentials { get; set; }

  }
}
