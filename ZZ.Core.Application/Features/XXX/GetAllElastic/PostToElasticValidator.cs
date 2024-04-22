using FluentValidation;
using ZZ.Core.Application.Features.XXX.GetAllElastic;

namespace ZZ.Core.Application.Features.XXX.GetAllElastic
{
  public class PostToElasticValidator : AbstractValidator<PostToElasticRequest>
  {
    public PostToElasticValidator()
    {
    }
  }
}
