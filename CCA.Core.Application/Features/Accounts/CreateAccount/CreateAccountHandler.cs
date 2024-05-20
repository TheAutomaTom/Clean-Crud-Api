using CCA.Core.Application.Features.Accounts.CreateAccount.CreateUser;
using CCA.Core.Application.Interfaces.Persistence.Accounts;
using CCA.Core.Domain.Models.Accounts;
using CCA.Core.Domain.Models.Accounts.Repo;
using CCA.Core.Infra.Models.Users;
using CCA.Core.Infra.ResultTypes;
using Mediator;
using Microsoft.Extensions.Logging;

namespace CCA.Core.Application.Features.Accounts.CreateAccount
{
	public class CreateAccountHandler : IRequestHandler<CreateAccountRequest, Result<AccountInfo>>
	{
		readonly IAccountSpecsRepository _accounts;
		readonly ILogger<CreateAccountHandler> _logger;
		readonly IMediator _mediator;

		public CreateAccountHandler(ILogger<CreateAccountHandler> logger, IMediator mediator, IAccountSpecsRepository accountsRepo)
		{
			_logger = logger;
			_mediator = mediator;
			_accounts = accountsRepo;
		}

		public async ValueTask<Result<AccountInfo>> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
		{
			var validator = new CreateAccountValidator();
			var validationResult = await validator.ValidateAsync(request);

			if (validationResult.Errors.Count > 0)
			{
				return Result<AccountInfo>.Fail(validationResult.Errors);
			}

			var createUser = await _mediator.Send(new CreateUserRequest(request));

			if (!createUser.IsOk)
			{
				return Result<AccountInfo>.Fail(new ExpectedError(ErrorCode.Unknown, "Failure during creating new user."));
			}
			var user = createUser.Data;
			var createAccountRequest = new AccountSpec( new Guid(user!.Guid), user.Username, user.FirstName, user.LastName, user.Email, user.EmailVerified, UserRole.Registered);

			var createAccountSpec = await _accounts.Create(createAccountRequest);
			if (createAccountSpec.Id == 0)
			{
				return Result<AccountInfo>.Fail(new ExpectedError(ErrorCode.Unknown, "Failure during creating new account."));
			}
			var accountSpec = createAccountSpec;

			// TODO: Add AccountDetail

			var accountInfo = new AccountInfo(accountSpec);
			return Result<AccountInfo>.Ok(accountInfo);


		}
	}
}
