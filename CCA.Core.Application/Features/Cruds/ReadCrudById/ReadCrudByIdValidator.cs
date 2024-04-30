using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Core.Application.Features.Cruds.ReadCrudById
{
  public class ReadCrudByIdValidator : AbstractValidator<ReadCrudByIdRequest>
  {
    public ReadCrudByIdValidator()
    {
      RuleFor(x => x.Id).GreaterThan(0);
    }


  }
}
