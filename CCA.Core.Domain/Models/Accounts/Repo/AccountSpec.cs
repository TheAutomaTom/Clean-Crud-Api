using CCA.Core.Infra.EntityUtilities;
using CCA.Core.Infra.Models.Users;

namespace CCA.Core.Domain.Models.Accounts.Repo
{
	public class AccountSpec : Auditable
	{
		public AccountSpec(Guid guid, string username, string firstName, string lastName, string email, bool emailVerified, UserRole userRole)
		{
			Guid = guid;
			Username = username;
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			EmailVerified = emailVerified;
			UserRole = userRole;
		}

		public AccountSpec() { }

		public Guid Guid { get; set; }
		public string Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public bool EmailVerified { get; set; }
		public UserRole UserRole { get; set; }




	}
}
