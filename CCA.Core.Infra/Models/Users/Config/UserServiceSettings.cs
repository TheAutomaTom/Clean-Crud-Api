namespace CCA.Core.Infra.Models.Users.Config
{
	public class UserServiceSettings
	{

		public string KeycloakRealm { get; set; }


		// Admin Client
		public string AdminClientId { get; set; } // `AdminClientId` is normal name string, like "clean-crud-api"
		public string AdminClientUuid { get; set; }
		public string AdminClientSecret { get; set; }


		// Ui Client
		public string UiClientId { get; set; }
		public string UiClientUuid { get; set; }
		public string UiClientSecret { get; set; }


		// Urls
		public string BaseAddress { get; set; }
		public string UserManagementPath { get; set; }
		public string PathToAdminToken { get; } = "/realms/master/protocol/openid-connect/token";
		public string PathToUserToken { get; } = "/realms/{{Realm}}/protocol/openid-connect/token";
		public string PathToGetUsers { get; } = "/admin/realms/{{Realm}}/users";
		public string PathToGetAllRoles { get; } = "/admin/realms/{{Realm}}/clients/{{Ui-Client-Uuid}}/roles";
		public string PathToGetRoleDetails { get; } = "/admin/realms/{{Realm}}/clients/{{Ui-Client-Uuid}}/roles/{{Role-Name}}";
		public string PathToAssignUseRole { get; } = "/admin/realms/{{Realm}}/users/{{User-Uuid}}/role-mappings/clients/{{Ui-Client-Uuid}}";



	}
}
