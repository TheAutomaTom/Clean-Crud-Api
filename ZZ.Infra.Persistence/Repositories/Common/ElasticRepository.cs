using Nest;
using ZZ.Core.Application.Interfaces.Persistence;
using ZZ.Core.Domain.Common;

namespace ZZ.Infra.Persistence.Repositories.Common
{
  public class ElasticRepository<T> : IAsyncRepository<T> where T : class
  {
    readonly IElasticClient _client;

    public ElasticRepository(IElasticClient client)
    {
      _client = client;
    }

    public async Task<int> Create(T item)
    {

      var indexRequest = new IndexRequest<T>(item);
      var result = await _client.IndexAsync(indexRequest);

      return Int32.Parse(result.Id);

    }

    public async Task<IReadOnlyList<T>> ReadAll()
    {
      var responses = _client.Search<T>(s =>
          s.Query(q => q
           .MatchAll()
          )
      );
      var results = new List<T>();
      foreach (var response in responses.Documents)
      {

        results.Add(response);
      }
      return results;

    }

    public async Task<T> ReadById(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<int> Update(T item)
    {
      throw new NotImplementedException();
    }

    public async Task<int> Delete(T item)
    {
      throw new NotImplementedException();
    }
  }
}
