using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Core.Application.Features.Accounts.LogIn
{
	public class LogInValidator : AbstractValidator<LogInRequest>
	{
		const int minUsernameLength = 50;
		const int minPasswordLength = 50;

		public LogInValidator()
		{


			RuleFor(x => x.Username)
				.NotEmpty().WithMessage("Username is required")
				.MaximumLength(minUsernameLength).WithMessage($"Username must not exceed {minUsernameLength} characters");
			RuleFor(x => x.Password)
				.NotEmpty().WithMessage("Password is required")
				.MaximumLength(minPasswordLength).WithMessage($"Password must not exceed {minPasswordLength} characters");

		}



	}
}
