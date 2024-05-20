using Azure.Core;
using CCA.Core.Application.Features.Accounts.CreateAccount;
using CCA.Core.Application.Features.Accounts.CreateAccount.CreateUser;
using CCA.Core.Application.Features.Accounts.LogIn;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CCA.Api.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
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
		public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequest request, CancellationToken ct)
		{
			var result = await _mediator.Send(request);

			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> LogIn(string username= "test-registered", string password= "Admin123!")
		{
			var request = new LogInRequest(username, password);
			var result = await _mediator.Send(request);

			return Ok(result);
		}



	}
}
