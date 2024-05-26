using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CCA.Core.Application.Interfaces.Infrastructure;
using CCA.Core.Infra.Models.Auth.Service.Config;
using CCA.Data.Infra.Auth;


namespace CCA.Data.Infra.Auth.Config
{
	public static class AuthServiceConfig
  {
    public static IServiceCollection AddAuthService(this IServiceCollection services, IConfiguration configuration)
    {
      var settings = configuration.GetSection("AuthServiceSettings");
      services.Configure<AuthServiceSettings>(settings);
      services.AddTransient<IManageAuth, AuthService>();

      return services;
    }
  }
}
