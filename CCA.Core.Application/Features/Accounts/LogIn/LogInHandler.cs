using CCA.Core.Application.Interfaces.Infrastructure;
using CCA.Core.Application.Interfaces.Persistence.Accounts;
using CCA.Core.Domain.Models.Accounts;
using CCA.Core.Infra.ResultTypes;
using Mediator;
using Microsoft.Extensions.Logging;

namespace CCA.Core.Application.Features.Accounts.LogIn
{
	public class LogInHandler : IRequestHandler<LogInRequest, Result<LogInResponse>>
	{
		readonly IManageUsers _users;
		readonly IAccountSpecsRepository _accounts;
		readonly ILogger<LogInHandler> _logger;

		public LogInHandler(ILogger<LogInHandler> logger, IManageUsers identities, IAccountSpecsRepository users)
		{
			_logger = logger;
			_users = identities;
			_accounts = users;
		}

		public async ValueTask<Result<LogInResponse>> Handle(LogInRequest request, CancellationToken cancellationToken)
		{
			var validator = new LogInValidator();
			var validationResult = await validator.ValidateAsync(request);

			if (validationResult.Errors.Count > 0)
			{
				return Result<LogInResponse>.Fail(validationResult.Errors);
			}

			try
			{
				var authInfo = await _users.AuthenticateUser(request.Username, request.Password);

				if (!authInfo.IsOk)
				{
					return Result<LogInResponse>.Fail(authInfo.ErrorList!);
				}

				var accountSpec = await _accounts.Read(authInfo.Data.User.Guid);
				// TODO: var accountDetail = await _accounts.Read(authInfo.Data.User.Guid);
				var accountInfo = new AccountInfo(accountSpec);

				var result = new LogInResponse(authInfo.Data, accountInfo);

				return new Result<LogInResponse>(result);

			}
			catch (Exception ex)
			{
				var response = new Result<LogInResponse>(ex);
				return response;
			}

		}



	}
}
