using Bogus;
using Microsoft.EntityFrameworkCore;
using CCA.Core.Domain.Models.Cruds.Repo;
using CCA.Data.Persistence.Repositories.Common;
using CCA.Core.Infra.Models.Search;
using CCA.Data.Persistence.Config.DbContexts;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using CCA.Core.Application.Interfaces.Persistence.Cruds;
using CCA.Core.Application.Interfaces.Persistence;
using CCA.Core.Infra.Models.Common;

namespace CCA.Data.Persistence.Repositories
{
  public class CrudEntityRepository : EFCoreRepository<CrudEntity>, IManageCrudEntities
  {
    readonly ILogger<AuditableEntity> _logger;
    public CrudEntityRepository(ILogger<AuditableEntity> logger, CrudContext dbContext) : base(dbContext)
    {
      _logger = logger;
    }

    public Task<int> Create(CrudEntity item)
    {
      throw new NotImplementedException();
    }

    Task<IReadOnlyList<CrudEntity>> IAsyncRepository<CrudEntity>.Read(Paging? paging, DateRange? dateRange)
    {
      throw new NotImplementedException();
    }

    public Task<bool> Update(CrudEntity item)
    {
      throw new NotImplementedException();
    }

    Task<CrudEntity> IAsyncRepository<CrudEntity>.Read(int id)
    {
      throw new NotImplementedException();
    }
  }
}
