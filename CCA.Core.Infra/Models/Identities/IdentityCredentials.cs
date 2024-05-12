using System.Text.Json.Serialization;

namespace CCA.Core.Infra.Models.Identities
{
  /// <summary> This class is dictated by a Keycloak model. </summary>
  public class IdentityCredentials
  {
    [JsonPropertyName("temporary")]
    public bool Temporary { get; } = false;

    [JsonPropertyName("type")]
    public string Type { get; } = "password";

    [JsonPropertyName("value")]
    public string Value { get; set; }

    public IdentityCredentials(string passwordValue)
    {
      Value = passwordValue;
      
    }

  }
}
