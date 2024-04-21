using FluentValidation;
using ZZ.XXX.Application.Features.XXX.GetAllElastic;
using ZZ.XXX.Application.Features.XXX.PostToElastic;

namespace ZZ.XXX.Application.Features.XXX.GetAllElastic
{
  public class PostToElasticValidator : AbstractValidator<PostToElasticRequest>
  {
    public PostToElasticValidator()
    {
    }
  }
}
