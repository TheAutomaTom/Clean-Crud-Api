using Bogus;
using CCA.Core.Application.Features.Cruds.CreateCrud;
using CCA.Core.Domain.Models.Cruds.Repo;
using StackExchange.Redis;
using Swashbuckle.AspNetCore.Filters;

namespace CCA.Api.Controllers.ExamplesRequests
{
	public class Example_CreateCrudRequest : IExamplesProvider<CreateCrudRequest>
	{
		readonly static Random _rando = new Random();
		readonly static int _descLength = _rando.Next(3, 15);
		readonly static int _tagsCount = _rando.Next(1, 8);

		/*
				{
					"name": "string",
					"department": "string",
					"description": "string",
					"tags": 
					[
						"string"
					]
				}
		*/
		public CreateCrudRequest GetExamples()
		{
			var faker = new Faker<CreateCrudRequest>()
					.RuleFor(s => s.Name, f => f.Commerce.ProductName())
					.RuleFor(s => s.Department, f => f.Commerce.Department())
					.RuleFor(x => x.Description, f => f.Lorem.Lines(_descLength))
					.RuleFor(x => x.Tags, f => f.Lorem.Words(_tagsCount));


			return faker.Generate();
		}
	}
}
