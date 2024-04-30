using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Domain.Models.Cruds.Repo;

namespace CCA.Core.Application.Interfaces.Persistence.Cruds
{
  public interface IManageCrudDetails : IAsyncRepository<CrudDetail>
  {
    /// <summary> Add Details to a list of CrudEntities </summary>
    /// <param name="entities">Entities to fulfill.</param>
    Task<IReadOnlyList<Crud>> Read(IEnumerable<CrudEntity> entities);

  }
}
