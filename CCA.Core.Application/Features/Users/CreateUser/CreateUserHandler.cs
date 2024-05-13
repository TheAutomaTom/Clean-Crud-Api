using CCA.Core.Application.Interfaces.Auth;
using CCA.Core.Infra.Models.Responses;
using Mediator;
using Microsoft.Extensions.Logging;
using CCA.Core.Infra.Models.Identities;

namespace CCA.Core.Application.Features.Users.CreateUser
{
  public class CreateUserHandler : IRequestHandler< CreateUserRequest, Result >
  {
    readonly ILogger<CreateUserHandler> _logger;
    readonly IManageIdentities _users;

    public CreateUserHandler(ILogger<CreateUserHandler> logger, IManageIdentities users)
    {
			_logger = logger;
			_users = users;
    }

    public async ValueTask<Result> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
      var validator = new CreateUserValidator();
      var validationResult = await validator.ValidateAsync(request);

      if (validationResult.Errors.Count > 0)
      {
        return Result<IdentityGetDto>.Fail(validationResult.Errors);
      }

      var user = request.ToDto();

      var result = await _users.CreateUser(user, request.Role);
      return result;

    }
  }
}
