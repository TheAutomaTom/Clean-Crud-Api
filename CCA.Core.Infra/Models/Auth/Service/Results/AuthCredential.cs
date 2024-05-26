using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CCA.Core.Infra.Models.Auth.Service.Results
{
	public class AuthCredential
	{
		public string AccessToken { get; set; }
		public string AuthUserId { get; set; }
		public string[] Roles { get; set; }




	}
}
