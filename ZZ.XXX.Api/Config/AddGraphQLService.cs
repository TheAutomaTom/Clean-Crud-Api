using ZZ.XXX;
using ZZ.XXX.GraphQL.Queries;

namespace ZZ.XXX.Config
{
  public static class AddGraphQLService
  {

    public static IServiceCollection AddGraphQLConfig(this IServiceCollection services, IConfiguration config)
    {

      services
        .AddGraphQLServer()          
        .AddQueryType<Query>();
      //.AddMutationType<BaseMutation>();
      //.AddMutationType<BaseSubscription>();

      return services;
    }


  }
}
