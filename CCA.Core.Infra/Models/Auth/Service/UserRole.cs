using System.ComponentModel;

namespace CCA.Core.Infra.Models.Auth.Service
{
	public enum UserRole
	{
		[Description("Unregistered")] Unregistered,
		[Description("Registered")] Registered

	}
}
