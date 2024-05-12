using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCA.Core.Domain.Models.Cruds.Repo;
using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Application.Features.Users.CreateUser;
using CCA.Core.Infra.Models.Identities;

namespace CCA.Core.Application.Interfaces.Auth
{
  public interface IManageIdentities
  {
    Task<IdentityGetDto> CreateUser(IdentityCreateDto user);



  }
}
