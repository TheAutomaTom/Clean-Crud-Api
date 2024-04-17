using Mediator;
using Microsoft.AspNetCore.Mvc;
using ZZ.XXX.Application.Features.XXX.GetXXXs;

namespace ZZ.XTEMPLATEX.Controllers
{
  /// <summary>
  /// Class Comment
  /// </summary>
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

    /// <summary>
    /// Method Comment
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Get()
    {
      var result = _mediator.Send(new GetXXXsRequest());

      return Ok(result);


    }
  }
}
