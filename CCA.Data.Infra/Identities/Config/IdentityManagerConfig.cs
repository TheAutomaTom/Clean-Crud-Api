using CCA.Core.Application.Interfaces.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CCA.Core.Infra.Models.Identities;


namespace CCA.Data.Infra.Identities.Config
{
  public static class IdentityManagerConfig
  {
    public static IServiceCollection AddUserIdentityService(this IServiceCollection services, IConfiguration configuration)
    {
      var settings = configuration.GetSection("IdentityManagerSettings");
      services.Configure<IdentityManagerSettings>(settings);
      services.AddTransient<IManageIdentities, IdentityManager>();

      return services;
    }
  }
}
