using CCA.Core.Plumbing.Models.Emails;

namespace CCA.Core.Application.Interfaces.Infrastructure
{
  public interface ISendEmails
  {
    Task<bool> SendEmail(Email email);
  }
}
