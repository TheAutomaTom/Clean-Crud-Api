using Microsoft.Extensions.DependencyInjection;

namespace ZZ.XXX.Application.DI
{
  public static class ApplicationDI
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
      services.AddMediator(o => o.ServiceLifetime = ServiceLifetime.Transient);             
      return services;
    }
  }
}
