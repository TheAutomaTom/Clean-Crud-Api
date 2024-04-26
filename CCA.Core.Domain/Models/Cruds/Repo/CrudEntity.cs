using CCA.Core.Domain.Common;
using CCA.Core.Domain.Models.Cruds.Repo;

namespace CCA.Core.Domain.Models.Cruds.Repo
{
  public class CrudEntity : AuditableEntity
  {
    public string Department { get; set; }
    public string Name { get; set; }

    public CrudEntity() { }

    /// <summary> Called for an existing Crud. </summary>
    public CrudEntity(CrudEntity entity)
    {
      Id = entity.Id;
      Department = entity.Department;
      Name = entity.Name;
    }

    /// <summary> For returning a new Crud with a newly assigned Id. </summary>
    public CrudEntity(int id, CrudEntity entity)
    {
      Id = id;
      Department = entity.Department;
      Name = entity.Name;
    }

    /// <summary> Called when creating a new Crud without an Id, yet. </summary>
    public CrudEntity(string department, string name)
    {
      Department = department;
      Name = name;
    }

  }
}
