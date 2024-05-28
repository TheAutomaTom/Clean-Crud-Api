using CCA.Core.Application.Interfaces.Infrastructure;
using CCA.Core.Application.Interfaces.Persistence.Accounts;
using CCA.Core.Infra.Models.Accounts.Entities;
using CCA.Core.Infra.Models.Accounts.Results;
using CCA.Core.Infra.Models.Auth.Service;
using CCA.Core.Infra.Models.Auth.Service.RequestDtos.Create;
using CCA.Core.Infra.ResultTypes;
using Mediator;
using Microsoft.Extensions.Logging;

namespace CCA.Core.Application.Features.Accounts.CreateAccount
{
	public class RegisterHandler : IRequestHandler<RegisterRequest, Result<AuthenticatedAccount>>
	{
		readonly IManageAuth _authService;
		readonly IAccountSpecsRepository _accountsRepo;
		readonly ILogger<RegisterHandler> _logger;

		public RegisterHandler(ILogger<RegisterHandler> logger, IManageAuth authService, IAccountSpecsRepository accountsRepo)
		{
			_logger = logger;
			_authService = authService;
			_accountsRepo = accountsRepo;
		}

		public async ValueTask<Result<AuthenticatedAccount>> Handle(RegisterRequest request, CancellationToken cancellationToken)
		{
			var validator = new RegisterValidator();
			var validationResult = await validator.ValidateAsync(request);

			if (validationResult.Errors.Count > 0)
			{
				return Result<AuthenticatedAccount>.Fail(validationResult.Errors);
			}

			try { 
				// Create a user in Keycloak
				var createUserRequest = new UserCreateRequestDto(
					request.Username, request.FirstName, request.LastName, request.Email, request.Password
				);
				var createUserResult = await _authService.CreateUser(createUserRequest);
				if (!createUserResult.IsOk)
				{
					return Result<AuthenticatedAccount>.Fail(new ExpectedError(ErrorCode.Unknown, "Failure during new user creation."));
				}
				var user = createUserResult.Data;


				// Create an account in the database
				var createAccountRequest = new UserEntity(new Guid(user!.Guid), user.Username, user.FirstName, user.LastName, user.Email, UserRole.Registered);
				var createAccountResult = await _accountsRepo.Create(createAccountRequest);
				if (createAccountResult.Id == 0)
				{
					return Result<AuthenticatedAccount>.Fail(new ExpectedError(ErrorCode.Unknown, "Failure during new account creation."));
				}

				// Authenticate the user for immediate login (future enhancement will require email verification step)
				var authCred = await _authService.AuthenticateUser(request.Username, request.Password);
				if (!createUserResult.IsOk)
				{
					return Result<AuthenticatedAccount>.Fail(new ExpectedError(ErrorCode.Unknown, "Failure to authenticate newly created account."));
				}

				// Return newly created, currently authenticated account
				var result = new AuthenticatedAccount(authCred.Data!, createAccountResult);
				return Result<AuthenticatedAccount>.Ok(result);

			}
			catch (Exception ex)
			{
				var response = new Result<AuthenticatedAccount>(ex);
				return response;
			}
		}



	}
}
