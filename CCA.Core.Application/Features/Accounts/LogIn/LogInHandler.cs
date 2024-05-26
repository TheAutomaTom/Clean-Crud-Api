using CCA.Core.Application.Interfaces.Infrastructure;
using CCA.Core.Application.Interfaces.Persistence.Accounts;
using CCA.Core.Infra.Models.Accounts.Results;
using CCA.Core.Infra.ResultTypes;
using CCA.Core.Infra.Services;
using Mediator;
using Microsoft.Extensions.Logging;

namespace CCA.Core.Application.Features.Accounts.LogIn
{
	public class LogInHandler : IRequestHandler<LogInRequest, Result<AuthenticatedAccount>>
	{
		readonly IManageAuth _authService;
		readonly IAccountSpecsRepository _accountsRepo;
		readonly ILogger<LogInHandler> _logger;

		public LogInHandler(ILogger<LogInHandler> logger, IManageAuth authService, IAccountSpecsRepository accountsRepo)
		{
			_logger = logger;
			_authService = authService;
			_accountsRepo = accountsRepo;
		}

		public async ValueTask<Result<AuthenticatedAccount>> Handle(LogInRequest request, CancellationToken cancellationToken)
		{
			var validator = new LogInValidator();
			var validationResult = await validator.ValidateAsync(request);

			if (validationResult.Errors.Count > 0)
			{
				return Result<AuthenticatedAccount>.Fail(validationResult.Errors);
			}

			try
			{
				// Get token from auth service
				var authAttempt = await _authService.AuthenticateUser(request.Username, request.Password);
				if (!authAttempt.IsOk)
				{
					return Result<AuthenticatedAccount>.Fail(authAttempt.ErrorList!);
				}


				// Get account data from database
				var account = await _accountsRepo.Read(authAttempt.Data!.AuthUserId);

				// Future enhancement: check if account has notifications, etc.				

				var result = new AuthenticatedAccount(authAttempt.Data, account);

				return new Result<AuthenticatedAccount>(result);

			}
			catch (Exception ex)
			{
				var response = new Result<AuthenticatedAccount>(ex);
				return response;
			}

		}



	}
}
