using Microsoft.Extensions.DependencyInjection;
using ZZ.XXX.Application.Interfaces.Persistence;

namespace ZZ.XXX.Application.DI
{
  public static class ApplicationDI
  {
    public static IServiceCollection AddCoreApplicationServices(this IServiceCollection services)
    {
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
      services.AddMediator(o => o.ServiceLifetime = ServiceLifetime.Transient);             
      return services;
    }
  }
}
