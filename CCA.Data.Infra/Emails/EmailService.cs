using Microsoft.Extensions.Options;
using CCA.Core.Application.Interfaces.Infrastructure;
using CCA.Core.Infra.Models.Emails;

namespace CCA.Data.Infra.Emails
{
  public class EmailService : ISendEmails
  {
    public EmailSettings Settings { get; }

    public EmailService(IOptions<EmailSettings> settings)
    {
      Settings = settings.Value;
    }

    public Task<bool> SendEmail(Email email)
    {
      throw new NotImplementedException();
    }
  }
}
