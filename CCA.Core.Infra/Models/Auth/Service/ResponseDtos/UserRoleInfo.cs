using System.Text.Json.Serialization;

namespace CCA.Core.Infra.Models.Auth.Service.ResponseDtos
{
	/// <summary> This is also the Dto to assign users to roles. </summary>
	public class UserRoleInfo
	{
		[JsonPropertyName("id")]
		public string Id { get; set; } // "f3cca280-062e-4b36-aa30-fdbedffda700",

		[JsonPropertyName("name")]
		public string Name { get; set; } // "Registered",


		[JsonPropertyName("description")]
		public string Description { get; set; } // "Can use GET endpoints",

		[JsonPropertyName("composite")]
		public bool Composite { get; set; } // false,

		[JsonPropertyName("clientRole")]
		public bool ClientRole { get; set; } // true,

		[JsonPropertyName("containerId")]
		public string ContainerId { get; set; } // "38f3017b-ca7f-4adc-91f1-e0810c99a4db"



	}
}
