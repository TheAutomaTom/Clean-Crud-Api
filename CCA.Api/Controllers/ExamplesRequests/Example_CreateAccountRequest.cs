using Bogus;
using CCA.Core.Domain.Models.Cruds.Repo;
using StackExchange.Redis;
using Swashbuckle.AspNetCore.Filters;
using CCA.Core.Infra.Models.Auth;
using CCA.Core.Application.Features.Accounts.Register;

namespace CCA.Api.Controllers.ExamplesRequests
{
	public class Example_CreateAccountRequest : IExamplesProvider<RegisterAccountRequest>
	{

		public RegisterAccountRequest GetExamples()
		{

			var faker =  new Faker<RegisterAccountRequest>()
				.RuleFor(x => x.Username, f => f.Person.UserName)
				.RuleFor(x => x.Email, f => f.Person.Email)
				.RuleFor(x => x.FirstName, f => f.Person.FirstName)
				.RuleFor(x => x.LastName, f => f.Person.LastName)
				.RuleFor(x => x.Password, f => "Admin123!")
				.RuleFor(x => x.Role, f => AuthUserRole.Registered);
			
			return faker.Generate();

		}



	}
}
