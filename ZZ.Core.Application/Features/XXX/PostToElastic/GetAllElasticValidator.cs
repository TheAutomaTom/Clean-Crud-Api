using FluentValidation;
using ZZ.Core.Application.Features.XXX.PostToElastic;

namespace ZZ.Core.Application.Features.XXX.PostToElastic
{
  public class GetAllElasticValidator : AbstractValidator<GetAllElasticRequest>
  {
    public GetAllElasticValidator()
    {
    }
  }
}
