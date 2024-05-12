using CCA.Core.Infra.Models.Identities;
namespace CCA.Core.Infra.Models.Identities
{
  /// <summary> For sending to Keycloak to search for users. </summary>
  public class IdentitySearchDto
  {
    public string Id { get; set; } // Guid
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string EmailVerified { get; set; }
    public string CreatedTimestamp { get; set; }

    public IdentitySearchParam[] SearchParams { get; set; }


  }
}

