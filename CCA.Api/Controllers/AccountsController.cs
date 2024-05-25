using CCA.Core.Application.Features.Accounts.LogIn;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using CCA.Core.Application.Features.Accounts.Register;

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
		public async Task<IActionResult> Register([FromBody] RegisterAccountRequest request, CancellationToken ct)
		{
			var result = await _mediator.Send(request);

			if (!result.IsOk)
			{
				return BadRequest(result.ErrorList);
			}
			return Ok(result.Data);

		}

		[HttpPost]
		public async Task<IActionResult> LogIn(string username= "test-registered", string password= "Admin123!")
		{
			var request = new LogInRequest(username, password);
			var result = await _mediator.Send(request);

			if(!result.IsOk)
			{
				return BadRequest(result.ErrorList);
			}
			return Ok(result.Data);
			
		}




	}
}
