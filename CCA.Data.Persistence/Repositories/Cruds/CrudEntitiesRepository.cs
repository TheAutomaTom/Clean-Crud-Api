using CCA.Core.Application.Interfaces.Persistence.Cruds;
using CCA.Core.Domain.Models.Cruds.Repo;
using CCA.Data.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using CCA.Data.Persistence.Config.DbContexts;
using CCA.Core.Infra.Models.SearchParams;

namespace CCA.Data.Persistence.Repositories.Cruds
{
	public class CrudEntitiesRepository : EfCoreRepository<CrudEntity>, ICrudEntitiesRepository
	{
		public CrudEntitiesRepository(GeneralDbContext context) : base(context)
		{

		}





	}
}
