namespace ZZ.XXX.Config
{
  public static class CorsConfig
  {

    public static string Policy = "corsPolicyName";
    public static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfiguration config)
    {      
      var allowedHosts = config.GetSection("AllowedHosts").Get<string>();
      services.AddCors(options =>
      {
        options.AddPolicy(name: Policy,
          policy =>
          {
            policy.WithOrigins(allowedHosts!)
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
      });

      return services;
    }


  }
}
