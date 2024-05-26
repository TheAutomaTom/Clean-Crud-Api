using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCA.Core.Infra.ResultTypes;
using CCA.Core.Infra.Models.Accounts.Results;

namespace CCA.Core.Application.Features.Accounts.LogIn
{
	public class LogInRequest : IRequest<Result<AuthenticatedAccount>>	
	{
		public LogInRequest( string username, string password )
		{
			Username = username;
			Password = password;
		}

		public string Username {get; set; }
		public string Password {get; set; }

	}
}
