using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Core.Infra.Models.Auth.Service.RequestDtos.Search
{
	public enum UserSearchParam
	{
		First,  // Page
		Max,    // Results per page

		Enabled,
		Username,
		FirstName,
		LastName,
		Email,
		EmailVerified,

		Search,
		Exact,
	}
}
