using Keycloak.AuthServices.Authorization;

namespace CCA.Api.Config
{
  public static class AuthConfig
  {

    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration config)
    {

      services.AddAuthorization(options =>
      {
        options.AddPolicy("Unregistered", p => { p.RequireResourceRoles("Unregistered" /* OR */, "Registered"); });
        options.AddPolicy("Registered", p => { p.RequireResourceRoles("Registered"); });
      });

      services.AddKeycloakAuthorization(config);

      return services;
    }


  }
}
