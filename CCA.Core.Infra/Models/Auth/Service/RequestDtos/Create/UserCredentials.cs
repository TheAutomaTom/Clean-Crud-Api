using System.Text.Json.Serialization;

namespace CCA.Core.Infra.Models.Auth.Service.RequestDtos.Create
{
	/// <summary> This class is dictated by a Keycloak model. </summary>
	public class UserCredentials
	{
		[JsonPropertyName("temporary")]
		public bool Temporary { get; } = false;

		[JsonPropertyName("type")]
		public string Type { get; } = "password";

		[JsonPropertyName("value")]
		public string Value { get; set; }

		public UserCredentials(string passwordValue)
		{
			Value = passwordValue;

		}

	}
}
