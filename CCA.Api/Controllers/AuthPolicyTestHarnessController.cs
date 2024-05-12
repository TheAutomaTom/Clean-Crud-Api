using CCA.Core.Application.Features.Cruds.CreateCrud;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CCA.Api.Controllers
{
  [ApiController]
  [Route("[controller]/[action]")]
  public class AuthPolicyTestHarnessController: Controller
  {
    readonly ILogger<AuthPolicyTestHarnessController> _logger;
    readonly IMediator _mediator;

    public AuthPolicyTestHarnessController(ILogger<AuthPolicyTestHarnessController> logger, IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator;
    }


    /// <summary> any-policy-accepted demonstrates that Unregistered or Registered roles are accepted. </summary>
    [HttpGet, Authorize(Policy = "Unregistered")]
    public IActionResult AnyPolicyAccepted() => Ok($"{nameof(AnyPolicyAccepted)} works!");


    [HttpGet, Authorize(Policy = "Registered")]
    public IActionResult RegisteredPolicyRequired() => Ok($"{nameof(RegisteredPolicyRequired)} works!");






  }
}
