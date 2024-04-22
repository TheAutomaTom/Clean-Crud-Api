using System.Text;
using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using ZZ.Core.Application.Interfaces.Persistence;
using ZZ.Core.Domain.Dtos.Elastic;
using ZZ.Infra.Persistence.Elastic;

namespace ZZ.Infra.Persistence.Config
{
  public static class ElasticConfig
  {

    public static void AddElasticsearch(this IServiceCollection services, IConfiguration config)
    {
      var url = config["Elastic:Url"];
      var user = config["Elastic:Username"];
      var pass = config["Elastic:Password"];
      var defaultIndex = config["Elastic:IndexUnconfigured"];
      var indexOfXXXs = config["Elastic:IndexOfXXXs"];

      var settings = new ConnectionSettings(new Uri(url))
          .PrettyJson() // Return human readable search results
          .DefaultIndex(defaultIndex)
          .DefaultMappingFor<XXXEls>(m => m.IndexName(indexOfXXXs))
          .BasicAuthentication(user, pass)
          //.EnableHttpCompression()
          .OnRequestCompleted(response => LogTransactions(response))
          .DisableDirectStreaming();

      var client = new ElasticClient(settings);

      client.Map<XXXEls>(m => m.Index(nameof(XXXEls)).AutoMap());

      services.AddSingleton<IElasticClient>(client);
      services.AddScoped<IXXXElasticRepository, XXXElasticRepository>();

    }


    public static void LogTransactions(IApiCallDetails details)
    {
      // Log request
      if (details.RequestBodyInBytes != null)
      {
        Console.WriteLine(
        $"{details.HttpMethod} {details.Uri} \n" +
            $"{Encoding.UTF8.GetString(details.RequestBodyInBytes)}\n\r");
      }
      else
      {
        Console.WriteLine($"{details.HttpMethod} {details.Uri}\n\r");
      }
      //Log details
      if (details.ResponseBodyInBytes != null)
      {
        Console.WriteLine(
            $"{details.HttpMethod} {details.Uri} \n");
      }
      else
      {
        Console.WriteLine($"Status: {details.HttpMethod}\n");
      }

      Console.WriteLine($"{new string('-', 30)}\n\r");
    }



  }
}
