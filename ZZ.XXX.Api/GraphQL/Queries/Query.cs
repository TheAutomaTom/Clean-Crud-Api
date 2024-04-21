namespace ZZ.XXX.GraphQL.Queries
{
  public class Query
  {
    //readonly ILogger<Query> _logger;

    //public Query(ILogger<Query> logger)
    //{
    //  _logger = logger;
    //}

    //public async Task<GetXXXByIdResponse> GetXXXById(int id, [Service] IMediator mediator )
    //{
    //    var request = new GetXXXByIdRequest(id);
    //    var response = await mediator.Send(request);

    //    return response;
    //}
    public async Task<string> GetString()
    {
      return "Working!";
    }


  }
}
