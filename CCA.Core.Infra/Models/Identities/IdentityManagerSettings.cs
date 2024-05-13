namespace CCA.Core.Infra.Models.Identities
{
  public class IdentityManagerSettings
  {
    public string ClientId { get; set; } // `ClientId` is normal name string, like "clean-crud-api"
    public string ApiClientUuid { get; set; }
    public string UiClientUuid { get; set; }
    public string ApiClientSecret { get; set; }
    public string KeycloakRealm { get; set; }
    public string BaseAddress { get; set; }
    public string UserManagementPath { get; set; }

    public string PathToAdminToken { get;  } = "/realms/master/protocol/openid-connect/token";
    public string PathToGetUser { get; } = "/admin/realms/{{Realm}}/users";
    public string PathToGetAllRoles { get; } = "/admin/realms/{{Realm}}/clients/{{Ui-Client-Uuid}}/roles";
    public string PathToGetRoleDetails { get; } = "/admin/realms/{{Realm}}/clients/{{Ui-Client-Uuid}}/roles/{{Role-Name}}";
    public string PathToAssignUseRole { get; } = "/admin/realms/{{Realm}}/users/{{User-Uuid}}/role-mappings/clients/{{Ui-Client-Uuid}}";



  }
}
