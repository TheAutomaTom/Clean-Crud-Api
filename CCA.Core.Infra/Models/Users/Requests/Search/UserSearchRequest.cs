using CCA.Core.Infra.Models.Users.Requests.Search;

namespace CCA.Core.Infra.Models.Users.Requests.Search
{
	/// <summary> For sending to Keycloak to search for users. </summary>
	public class UserSearchRequest
	{
		public bool  Exact { get; set; }
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
