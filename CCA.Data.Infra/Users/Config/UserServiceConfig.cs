using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CCA.Core.Infra.Models.Users.Config;
using CCA.Core.Application.Interfaces.Infrastructure;
using CCA.Data.Infra.Users;


namespace CCA.Data.Infra.Users.Config
{
	public static class UserServiceConfig
  {
    public static IServiceCollection AddUserService(this IServiceCollection services, IConfiguration configuration)
    {
      var settings = configuration.GetSection("UserServiceSettings");
      services.Configure<UserServiceSettings>(settings);
      services.AddTransient<IManageUsers, UserService>();

      return services;
    }
  }
}
