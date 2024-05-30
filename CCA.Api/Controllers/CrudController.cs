using CCA.Core.Application.Ancillary;
using CCA.Core.Application.Features.Cruds.CreateCrud;
using CCA.Core.Application.Features.Cruds.DeleteCrudById;
using CCA.Core.Application.Features.Cruds.ReadCrudById;
using CCA.Core.Application.Features.Cruds.ReadCruds;
using CCA.Core.Application.Features.Cruds.UpdateCrud;
using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Infra.Models.SearchParams;
using CCA.Core.Infra.ResultTypes;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CCA.Api.Controllers
{
	/// <summary> Basic C.R.U.D. operations on an example object. </summary>
	[ApiController]
	[Route("api-v1/[controller]/[action]")]
	public class CrudController : Controller
	{
		readonly ILogger<CrudController> _logger;
		readonly IMediator _mediator;
		//IOutputCacheStore _cache;

		public CrudController(ILogger<CrudController> logger, IMediator mediator) //, IOutputCacheStore cache)
		{
			_logger = logger;
			_mediator = mediator;
			//_cache = cache;
		}

		[HttpPost]
		public async Task<ActionResult<Crud>> Create([FromBody] CreateCrudRequest request, CancellationToken ct = default)
		{
			try
			{
				var result = await _mediator.Send(request);

				if (!result.IsOk)
				{
					return BadRequest(result.ErrorList);
				}
				return Ok(result.Data);

			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}

			//await _cache.EvictByTagAsync("Crud-Reader", ct);

		}

		/// <summary> Create and save randomized Cruds. </summary>
		/// <param name="count"> The number of new Cruds to create. </param>
		/// <returns> Newly created Cruds. </returns>
		[HttpPost]
		public async Task<IActionResult> SeedDb(int count = 3, CancellationToken ct = default)
		{
			var faker = new CrudMocker();
			var cruds = faker.Generate(count);

			var results = new List<Crud>();
			foreach (var crud in cruds)
			{
				var request = new CreateCrudRequest(crud);
				var result = await _mediator.Send(request);
				results.Add(result.Data!);
			}

			//await _cache.EvictByTagAsync("Crud-Reader", ct);
			return Ok(new { Count = results.Count, Cruds = results });
		}



		[HttpGet]
		//[OutputCache(Tags =["Crud-Reader"])]
		public async Task<ActionResult<ReadCrudsResponse>> Read(int page = 1, int perPage = 10, DateTime? updatedFrom = null, DateTime? updatedUntil = null, CancellationToken ct = default)
		{
			try
			{
				updatedFrom = updatedFrom ?? DateTime.MinValue;
				updatedUntil = updatedUntil ?? DateTime.MaxValue;

				var request = new ReadCrudsRequest(new Paging(page, perPage), new DateRangeFilter(updatedFrom, updatedUntil));
				var result = await _mediator.Send(request);
				
				if (!result.IsOk)
				{
					return BadRequest(result.ErrorList);
				}
				return Ok(result.Data);

			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}


    [HttpGet]
    //[OutputCache(Tags = ["Crud-Reader"])]
    public async Task<ActionResult<Crud>> ReadById(int id)
    {
      var request = new ReadCrudByIdRequest(id);
      var result = await _mediator.Send(request);

			if (!result.IsOk)
			{
				return BadRequest(result.ErrorList);
			}
			return Ok(result.Data);
		}


    [HttpPut]
    public async Task<ActionResult<Crud>> Update([FromBody] UpdateCrudRequest request, CancellationToken ct = default)
    {
      var result = await _mediator.Send(request);

			// If the item did not exist, send to typical `Create()` workflow.
			foreach (var error in result.ErrorList)
			{
				if(error.Type == ErrorCode.DoesNotExist )
				{
					var create = new CreateCrudRequest(request);
					result = await _mediator.Send(create);
				}
			}

			//await _cache.EvictByTagAsync("Crud-Reader", ct);

			if (!result.IsOk)
			{
				return BadRequest(result.ErrorList);
			}
			return Ok(result.Data);

		}



    [HttpDelete]
    public async Task<IActionResult> DeleteById(int id, CancellationToken ct = default)
    {
      var request = new DeleteCrudByIdRequest(id);
      var result = await _mediator.Send(request);

			//await _cache.EvictByTagAsync("Crud-Reader", ct);

			if (!result.IsOk)
			{
				// TODO: Check for NotFound error and return NotFound() instead of BadRequest()
				return BadRequest(result.ErrorList);
			}
			return Ok($"Crud id#{id} deleted");

		}




  }
}

