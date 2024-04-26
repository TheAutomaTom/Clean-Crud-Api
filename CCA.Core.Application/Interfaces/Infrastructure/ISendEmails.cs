using ZZ.Core.Plumbing.Models.Emails;

namespace ZZ.Core.Application.Interfaces.Infrastructure
{
  public interface ISendEmails
  {
    Task<bool> SendEmail(Email email);
  }
}
