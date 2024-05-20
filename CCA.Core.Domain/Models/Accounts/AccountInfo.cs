using CCA.Core.Domain.Models.Accounts.Repo;

namespace CCA.Core.Domain.Models.Accounts
{
	public class AccountInfo
	{
		public AccountSpec AccountSpec { get; set; }

		public AccountInfo(AccountSpec accountSpec)
		{
			AccountSpec = accountSpec;
		}



	}
}
