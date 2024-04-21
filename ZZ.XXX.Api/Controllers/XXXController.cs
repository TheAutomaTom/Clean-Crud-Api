using Bogus;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using ZZ.XXX.Application.Features.XXX.GetXXXs;
using ZZ.XXX.Application.Features.XXX.PostToElastic;
using ZZ.XXX.Domain.Dtos.Elastic;

namespace ZZ.XXX.Controllers
{
  /// <summary> Class Comment </summary>
  [ApiController]
  [Route("[controller]/[action]")]
  public class XXXController : ControllerBase
  {
    readonly ILogger<XXXController> _logger;
    readonly IMediator _mediator;

    public XXXController(ILogger<XXXController> logger, IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator;
    }



    /// <summary> Method Comment </summary>
    [HttpGet]
    public async Task<ActionResult<GetXXXsRequest>> GetAllXxxs(CancellationToken ct = default)
    {
      try
      {
        /* If there were params taken, this is where the request would be validated before attempting to process. */
        //var validator = new GetXXXsValidator();
        //var validationResult = await validator.ValidateAsync(param, ct);
        //if (!validationResult.IsValid)
        //{
        //  return new GetXXXsResponse(null) { ValidationErrors = validationResult.Errors };
        //}

        var result = await _mediator.Send(new GetXXXsRequest());

        if (!result.IsOk)
        {
          return BadRequest(result);
        }

        if (result.XXXs == null || result.XXXs.Count() == 0)
        {
          return NotFound();
        }

        return Ok(result);

      }
      catch (Exception ex)
      {
        var result = new GetXXXsResponse(null) { Exception = ex };
        return StatusCode(StatusCodes.Status500InternalServerError, result);
      }



    }



    /// <summary> Get all Elastic XXXs  </summary>
    [HttpGet]
    public async Task<IActionResult> GetAllElasticXxxs(CancellationToken ct = default)
    {
      try
      {

        var results = await _mediator.Send(new GetAllElasticRequest());

        return Ok(results);

      } catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }

    }




    /// <summary> Method Comment </summary>
    [HttpPost]
    public async Task<IActionResult> PostToElastic(CancellationToken ct = default)
    {
      var faker = new Faker<XXXEls>()
        .RuleFor(x => x.Id, f => f.Random.Int()) // Ideally, this would be assigned after an EFCore save to coordinate repos.
        .RuleFor(x => x.Name, f => f.Name.FirstName())
        .RuleFor(x => x.Description, f => f.Lorem.Sentence());

      try
      {
        var dto = faker.Generate(1).First();

        var result = await _mediator.Send(new PostToElasticRequest(dto));

        if (!result.IsOk)
        {
          return BadRequest(result);
        }

        return Ok(result);

      }
      catch (Exception ex)
      {
        var result = new GetXXXsResponse(null) { Exception = ex };
        return StatusCode(StatusCodes.Status500InternalServerError, result);
      }
    }



    [HttpDelete]
    public async Task<IActionResult> IntentionallyThrow(string someParameter)
    {
      _logger.LogInformation("IntentionallyThrow() Begin");

      try
      {
        throw new Exception("IntentionallyThrow() Exception Message!");
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "IntentionallyThrow() Exception", someParameter);
        return BadRequest(ex.Message);
      }

    }



  }
}
