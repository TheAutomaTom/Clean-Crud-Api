using Lkq.Api.Thing2.GraphQL.Queries;

namespace ZZ.XXX.DI
{
  public static class AddGraphQLService
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
