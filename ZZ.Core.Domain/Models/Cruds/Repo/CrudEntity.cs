using ZZ.Core.Domain.Common;

namespace ZZ.Core.Domain.Models.Cruds.Repo
{
  public class CrudEntity : AuditableEntity
  {
    public string Department { get; set; }
    public string Name { get; set; }

    public CrudEntity(){ }

    /// <summary> Called when creating a completed Crud. </summary>
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
