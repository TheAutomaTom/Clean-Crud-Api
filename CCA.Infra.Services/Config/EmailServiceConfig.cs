using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CCA.Core.Application.Interfaces.Infrastructure;
using CCA.Data.Infra.Emails;
using CCA.Core.Infra.Models.Emails;

namespace CCA.Data.Infra.Config
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
