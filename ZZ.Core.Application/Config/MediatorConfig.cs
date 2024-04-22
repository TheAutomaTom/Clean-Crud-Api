using Microsoft.Extensions.DependencyInjection;

namespace ZZ.Core.Application.Config
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
