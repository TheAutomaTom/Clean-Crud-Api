using ZZ.XXX.Domain.Common.Responses;

namespace ZZ.XXX.Application.Features.XXX.PostToElastic
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
