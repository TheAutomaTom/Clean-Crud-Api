using System.Text.Json.Serialization;
using CCA.Core.Infra.Models.Identities;

namespace CCA.Core.Infra.Models.Identities
{
  /// <summary> For receiving a user from Keycloak. </summary>
  public class IdentityGetDto
  {
    [JsonPropertyName("id")]
    public string Id {get; set;} // Guid

    [JsonPropertyName("username")]
    public string Username {get; set;}

    [JsonPropertyName("firstName")]
    public string FirstName {get; set;}

    [JsonPropertyName("lastName")]
    public string LastName {get; set;}

    [JsonPropertyName("email")]
    public string Email {get; set;}

    [JsonPropertyName("emailVerified")]
    public bool   EmailVerified {get; set;}


    // TODO: Create long-to-datetime parser

    [JsonPropertyName("createdTimestamp")]
    public long    CreatedTimestamp {get; set;}


    [JsonPropertyName("enabled")]
    public bool   Enabled {get; set;}

    [JsonPropertyName("totp")]
    public bool   Totp {get; set;}

    [JsonPropertyName("notBefore")]
    public int    NotBefore {get; set;} 


  }
}
