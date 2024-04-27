using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Core.Application.Features.Cruds.UpdateCrud
{
  public class UpdateCrudValidator : AbstractValidator<UpdateCrudRequest>
  {
    public UpdateCrudValidator()
    {

      RuleFor(x => x.Id).GreaterThan(0).WithMessage("Crud Id is required for update requests.  You may want to Create a new Crud.");
    }
  }
}
