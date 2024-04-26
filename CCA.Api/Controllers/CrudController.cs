using CCA.Core.Application.Ancillary;
using CCA.Core.Application.Features.Cruds.CreateCrud;
using CCA.Core.Domain.Models.Cruds;
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

      return Ok(new {Count= results.Count, Cruds= results});
    }


  }
}
