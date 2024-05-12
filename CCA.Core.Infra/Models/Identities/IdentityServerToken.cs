using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CCA.Core.Infra.Models.Identities
{
  public class IdentityServerToken
  {
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } 

    [JsonPropertyName("expires_in")]
    public int ExpiresInSeconds{ get; set; } 

    [JsonPropertyName("refresh_expires_in")]
    public int RefreshExpiresInSeconds{ get; set; }

    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }

    [JsonPropertyName("not-before-policy")]
    public int NotBeforePolicy { get; set; }

    [JsonPropertyName("scope")]
    public string Scope { get; set; }






  }
}
