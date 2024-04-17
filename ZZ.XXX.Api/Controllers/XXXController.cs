using Azure.Core;
using System.Threading;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using ZZ.XXX.Application.Features.XXX.GetXXXs;

namespace ZZ.XTEMPLATEX.Controllers
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
    public async Task<ActionResult<GetXXXsRequest>> GetAll(CancellationToken ct = default)
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

        if(result.XXXs == null || result.XXXs.Count() == 0)
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
  }
}
