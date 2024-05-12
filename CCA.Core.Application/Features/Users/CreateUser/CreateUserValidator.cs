using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Core.Application.Features.Users.CreateUser
{
  public class CreateUserValidator : AbstractValidator<CreateUserRequest>
  {
    public CreateUserValidator()
    {
    }
  }
}
