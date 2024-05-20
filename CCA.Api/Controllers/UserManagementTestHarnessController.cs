using CCA.Core.Application.Features.Accounts.CreateAccount.CreateUser;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CCA.Api.Controllers
{
	[ApiController]
  [Route("[controller]/[action]")]
  public class UserManagementTestHarnessController : Controller
  {
    readonly ILogger<UserManagementTestHarnessController> _logger;
    readonly IMediator _mediator;

    public UserManagementTestHarnessController(ILogger<UserManagementTestHarnessController> logger, IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken ct = default)
    {
      var result = await _mediator.Send(request);

      return Ok(result);
    }






  
  
  
    
  
  }
}
