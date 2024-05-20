using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Core.Infra.Models.Users.Results
{
	public class AuthenticationInfo
	{
		public User User { get; set; }
		public UserTokenInfo Token { get; set; }

	}
}
