namespace CCA.Core.Infra.Models.Identities
{
  public class IdentityManagerSettings
  {
    public string ClientId { get; set; } // `ClientId` is normal name string, like "clean-crud-api"
    public string ClientUuid { get; set; }
    public string ClientSecret { get; set; }
    public string KeycloakRealm { get; set; }
    public string BaseAddress { get; set; }
    public string UserManagementPath { get; set; }

    public string PathToAdminToken { get;  } = "/realms/master/protocol/openid-connect/token";
    public string PathToGetUser { get; } = "/admin/realms/{{Keycloak-Realm}}/users";



  }
}
