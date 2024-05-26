using CCA.Core.Infra.Models.Common;
using CCA.Core.Infra.Models.Auth.Service;

namespace CCA.Core.Infra.Models.Accounts.Entities
{
	public class UserEntity : AuditableEntity
	{
		public UserEntity(Guid guid, string username, string firstName, string lastName, string email,UserRole userRole)
		{
			Guid = guid;
			Username = username;
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			UserRole = userRole;
			
			// For future enhancements
			EmailVerified = true;
			Enabled = true;
		}

		public UserEntity() { }

		public Guid Guid { get; set; }
		public string Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public bool EmailVerified { get; set; }
		public UserRole UserRole { get; set; }
		public bool Enabled { get; set; }


	}
}
