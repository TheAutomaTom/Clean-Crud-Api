using Mediator;
using Microsoft.Extensions.Logging;
using CCA.Core.Infra.ResultTypes;
using CCA.Core.Infra.Models.Users.Results;
using CCA.Core.Application.Interfaces.Infrastructure;

namespace CCA.Core.Application.Features.Accounts.CreateAccount.CreateUser
{
	public class CreateUserHandler : IRequestHandler< CreateUserRequest, Result<User> >
	{
		readonly ILogger<CreateUserHandler> _logger;
		readonly IManageUsers _users;

		public CreateUserHandler(ILogger<CreateUserHandler> logger, IManageUsers users)
		{
			_logger = logger;
			_users = users;
		}

		public async ValueTask<Result<User>> Handle(CreateUserRequest request, CancellationToken cancellationToken)
		{
			var validator = new CreateUserValidator();
			var validationResult = await validator.ValidateAsync(request);

			if (validationResult.Errors.Count > 0)
			{
				return Result<User>.Fail(validationResult.Errors);
			}

			var user = request.AsKeycloakRequest();

			var result = await _users.CreateUser(user, request.Role);
			return result;

		}



	}
}
