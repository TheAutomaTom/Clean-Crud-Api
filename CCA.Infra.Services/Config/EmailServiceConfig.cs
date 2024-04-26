using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CCA.Core.Application.Interfaces.Infrastructure;
using CCA.Core.Plumbing.Models.Emails;
using CCA.Infra.Services.Emails;

namespace CCA.Infra.Services.Config
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
