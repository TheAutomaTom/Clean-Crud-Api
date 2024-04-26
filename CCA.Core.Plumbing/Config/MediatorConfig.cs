using Microsoft.Extensions.DependencyInjection;

namespace CCA.Core.Plumbing.Config
{
  public static class MediatorConfig
  {
    public static IServiceCollection AddMeditorSupport(this IServiceCollection services)
    {
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
      services.AddMediator(o => o.ServiceLifetime = ServiceLifetime.Transient);
      return services;
    }
  }
}
