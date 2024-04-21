using ZZ.XXX.Domain.Common.Responses;
using ZZ.XXX.Application.Features.XXX.PostToElastic;

namespace ZZ.XXX.Application.Features.XXX.GetAllElastic
{
  public class PostToElasticResponse : BasicResponse
  {
    public PostToElasticResponse(string result)
    {
      Result = result;
      IsOk = Result == "Created";
    }

    public string Result { get; set; }
  }
}
