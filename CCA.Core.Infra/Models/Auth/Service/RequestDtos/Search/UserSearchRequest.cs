using CCA.Core.Infra.Models.Auth.Service.RequestDtos.Search;

namespace CCA.Core.Infra.Models.Auth.Service.RequestDtos.Search
{
	/// <summary> For sending to Keycloak to search for users. </summary>
	public class UserSearchRequest
	{
		public bool Exact { get; set; }
		public string Id { get; set; } // Guid
		public string Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string EmailVerified { get; set; }
		public string CreatedTimestamp { get; set; }

		public UserSearchParam[] SearchParams { get; set; }


	}
}
