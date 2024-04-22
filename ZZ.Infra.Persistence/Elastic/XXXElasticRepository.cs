using Microsoft.Extensions.Logging;
using Nest;
using ZZ.Core.Application.Interfaces.Persistence;
using ZZ.Core.Domain.Dtos.Elastic;
using ZZ.Infra.Persistence.Elastic;

namespace ZZ.Infra.Persistence.Elastic
{
  public class XXXElasticRepository : IXXXElasticRepository
  {
    readonly IElasticClient _client;
    readonly ILogger<XXXElasticRepository> _logger;


    public XXXElasticRepository(ILogger<XXXElasticRepository> logger, IElasticClient client)
    {
      _logger = logger;
      _client = client;
    }


    public async Task<string> Create(XXXEls document)
    {

      var indexRequest = new IndexRequest<XXXEls>(document);
      var result = await _client.IndexAsync(indexRequest);

      return $"{result.Result.ToString()}: {result.Id}";
    }


    public async Task<IEnumerable<XXXEls>> GetAll()
    {
      var responses = _client.Search<XXXEls>(s =>
          s.Query(q => q
           .MatchAll()
          )
      );
      var results = new List<XXXEls>();
      foreach (var response in responses.Documents)
      {

        results.Add(response);
      }
      return results;

    }



  }
}
