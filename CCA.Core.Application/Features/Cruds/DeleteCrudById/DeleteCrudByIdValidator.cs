using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Core.Application.Features.Cruds.DeleteCrudById
{
  public class DeleteCrudByIdValidator : AbstractValidator<DeleteCrudByIdRequest>
  {
    public DeleteCrudByIdValidator()
    {
      RuleFor(x => x.Id).GreaterThan(0);
    }
  }
}
