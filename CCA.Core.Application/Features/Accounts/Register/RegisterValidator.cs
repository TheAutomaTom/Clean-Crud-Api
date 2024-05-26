using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Core.Application.Features.Accounts.CreateAccount
{
	public class RegisterValidator : AbstractValidator<RegisterRequest>
	{
		public RegisterValidator()
		{
		}
	}
}
