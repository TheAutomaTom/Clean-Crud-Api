using ZZ.Core.Domain.Common.Responses;

namespace ZZ.Core.Application.Features.XXX.GetAllElastic
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
