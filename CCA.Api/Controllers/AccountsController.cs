using CCA.Core.Application.Features.Accounts.CreateAccount;
using CCA.Core.Application.Features.Accounts.LogIn;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CCA.Api.Controllers
{
	[ApiController]
	[Route("api-v1/[controller]/[action]")]
	public class AccountsController : Controller
	{
		readonly ILogger<AccountsController> _logger;
		readonly IMediator _mediator;

		public AccountsController(ILogger<AccountsController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Register([FromBody] RegisterRequest request, CancellationToken ct)
		{
			var result = await _mediator.Send(request);

			if (!result.IsOk)
			{
				return BadRequest(result.ErrorList);
			}
			return Ok(result.Data);

		}



		[HttpPost]
		public async Task<IActionResult> LogIn([FromBody] LogInRequest request)
		{		
			var result = await _mediator.Send(request);

			if(!result.IsOk)
			{
				return BadRequest(result.ErrorList);
			}
			return Ok(result.Data);
			
		}

	}
}
