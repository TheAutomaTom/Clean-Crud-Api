using Microsoft.Extensions.DependencyInjection;
using Whether_Advisory.XXX.Application.Interfaces.Persistence;

namespace Whether_Advisory.XXX.Application.Config
{
  public static class CoreApplicationDI
  {
    public static IServiceCollection AddCoreApplicationServices(this IServiceCollection services)
    {
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
      services.AddMediator(o => o.ServiceLifetime = ServiceLifetime.Transient);             
      return services;
    }
  }
}
