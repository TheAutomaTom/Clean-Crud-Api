using ZZ.XXX.GraphQL.Queries;

namespace ZZ.XXX.Config
{
  public static class GraphQLConfig
  {

    public static IServiceCollection AddGraphQL(this IServiceCollection services, IConfiguration config)
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
