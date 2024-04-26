using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZZ.Infra.Services.Emails;
using ZZ.Core.Application.Interfaces.Infrastructure;
using ZZ.Core.Plumbing.Models.Emails;

namespace ZZ.Infra.Services.Config
{
  public static class EmailServiceConfig
  {
    public static IServiceCollection AddEmailService(this IServiceCollection services, IConfiguration configuration)
    {
      var settings = configuration.GetSection("EmailSettings");
      services.Configure<EmailSettings>(settings);
      services.AddTransient<ISendEmails, EmailService>();

      return services;
    }
  }
}
