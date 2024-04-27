using CCA.Core.Application.Ancillary;
using CCA.Core.Application.Features.Cruds.CreateCrud;
using CCA.Core.Application.Features.Cruds.DeleteCrudById;
using CCA.Core.Application.Features.Cruds.ReadCrudById;
using CCA.Core.Application.Features.Cruds.ReadCruds;
using CCA.Core.Application.Features.Cruds.UpdateCrud;
using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Infra.Models.Search;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CCA.Api.Controllers
{
  /// <summary> Basic C.R.U.D. operations on an example object. </summary>
  [ApiController]
  [Route("[controller]/[action]")]
  public class CrudController : Controller
  {
    readonly ILogger<CrudController> _logger;
    readonly IMediator _mediator;

    public CrudController(ILogger<CrudController> logger, IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCrudRequest request)
    {
      var result = await _mediator.Send(request);

      return Ok(result);
    }

    /// <summary> Create and save randomized Cruds. </summary>
    /// <param name="count"> The number of new Cruds to create. </param>
    /// <returns> Newly created Cruds. </returns>
    [HttpPost]
    public async Task<IActionResult> SeedDb(int count)
    {
      var faker = new CrudMocker();
      var cruds = faker.Generate(count);

      var results = new List<Crud>();
      foreach (var crud in cruds)
      {
        var request = new CreateCrudRequest(crud);
        var result = await _mediator.Send(request);

        results.Add(result.Crud!);
      }

      return Ok(new { Count = results.Count, Cruds = results });
    }



    [HttpGet]
    public async Task<IActionResult> Read(int page = 1, int perPage = 1, DateTime? updatedFrom = null, DateTime? updatedUntil = null)
    {
      updatedFrom = updatedFrom ?? DateTime.MinValue;
      updatedUntil = updatedUntil ?? DateTime.MaxValue;


      var request = new ReadCrudsRequest(new Paging(page, perPage), new DateRange(updatedFrom, updatedUntil));
      var result = await _mediator.Send(request);

      return Ok(result);
    }


    [HttpGet]
    public async Task<IActionResult> ReadById(int id)
    {
      var request = new ReadCrudByIdRequest(id);
      var result = await _mediator.Send(request);

      return Ok(result);
    }


    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCrudRequest request)
    {
      var result = await _mediator.Send(request);

      // If the item did not exist, create it.
      if (result.Exception != null)
      {


        var create = new CreateCrudRequest(request);

        result = await _mediator.Send(create);
      }
        return Ok(result);
    }



    [HttpGet]
    public async Task<IActionResult> DeleteById(int id)
    {
      var request = new DeleteCrudByIdRequest(id);
      var result = await _mediator.Send(request);

      return Ok(result);
    }




  }
}

