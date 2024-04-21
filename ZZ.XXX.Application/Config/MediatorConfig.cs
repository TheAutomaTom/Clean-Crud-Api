using Microsoft.Extensions.DependencyInjection;

namespace ZZ.XXX.Application.Config
{
  public static class MediatorConfig
  {
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
      services.AddMediator(o => o.ServiceLifetime = ServiceLifetime.Transient);
      return services;
    }
  }
}
