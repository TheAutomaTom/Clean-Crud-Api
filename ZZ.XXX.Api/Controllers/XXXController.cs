using Microsoft.AspNetCore.Mvc;

namespace Whether_Advisory.XTEMPLATEX.Controllers
{
  /// <summary>
  /// Class Comment
  /// </summary>
  [ApiController]
  [Route("[controller]/[action]")]
  public class XXXController : ControllerBase
  {

    private readonly ILogger<XXXController> _logger;

    public XXXController(ILogger<XXXController> logger)
    {
      _logger = logger;
    }

    /// <summary>
    /// Method Comment
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Get()
    {
      return Ok("Noice!");
    }
  }
}
