using CCA.Core.Infra.Models.Identities;
using CCA.Core.Infra.Models.Responses;

namespace CCA.Core.Application.Interfaces.Auth
{
  public interface IManageIdentities
  {
    Task<Result> CreateUser(IdentityCreateDto user, string role);



  }
}
