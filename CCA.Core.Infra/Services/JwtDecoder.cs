using System.IdentityModel.Tokens.Jwt;
using CCA.Core.Infra.Models.Auth.Service.ResponseDtos;
using CCA.Core.Infra.Models.Auth.Service.Results;

namespace CCA.Core.Infra.Services
{
	public class JwtDecoder
	{
		readonly JwtSecurityTokenHandler _handler;
		public JwtDecoder()
		{
			_handler = new JwtSecurityTokenHandler();
		}


		/* Sample of relevant jwt items:
			{
				"sub": "a448f2f4-f080-4885-b920-d43fed718445", // <==== This is the user's guid, aka "Subject"
				...
			}
		*/
		public AuthCredential Decode(string accessToken)
		{
			var jsonToken = _handler.ReadToken(accessToken) as JwtSecurityToken;

			var result = new AuthCredential()
			{
				AccessToken = accessToken,
				AuthUserId = jsonToken!.Subject,
				Roles = jsonToken!.Claims.Where(c => c.Type == "roles").Select(c => c.Value).ToArray()
			};
			return result;

		}





	}
}
