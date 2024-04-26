using FluentValidation;

namespace CCA.Core.Application.Features.Cruds.CreateCrud
{
  public class CreateCrudValidator : AbstractValidator<CreateCrudRequest>
  {
    public CreateCrudValidator()
    {
      RuleFor(x => x.Name).MinimumLength(3).WithMessage("Name must be at least 3 characters long");
      RuleFor(x => x.Department).MinimumLength(3).WithMessage("Department must be at least 3 characters long");
      RuleFor(x => x.Description).MinimumLength(3).WithMessage("Description must be at least 3 characters long");
    }



  }
}
