using CCA.Core.Application.Features.Cruds.ReadCruds;
using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Infra.Models.SearchParams;
using HotChocolate.Authorization;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CCA.Api.GraphQL.Queries
{
  public class CrudQueries
	{
		readonly ILogger<CrudQueries> _logger;
		public CrudQueries(ILogger<CrudQueries> logger)
		{
			_logger = logger;
		}


		////[Authorize(Policy = "Readers")]
		public async Task<ReadCrudsResponse> ReadCruds([Service] IMediator mediator, int page = 1, int perPage = 10, DateTime? updatedFrom = null, DateTime? updatedUntil = null)
		{
			try
			{
				var request = new ReadCrudsRequest(new Paging(page, perPage), new DateRangeFilter(updatedFrom, updatedUntil));

				var result = await mediator.Send(request);



				//if (!result.IsOk)
				//{
				//	return result.ErrorList;
				//}
				return result.Data;



			}
			catch (Exception ex)
			{
				//return ex;
				_logger.LogError(ex, "Error in GraphQl/ReadCruds");
				throw;
			}
		}


	}
}
