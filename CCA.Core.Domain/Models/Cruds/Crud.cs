using CCA.Core.Domain.Models.Cruds.Repo;

namespace CCA.Core.Domain.Models.Cruds
{
  public class Crud : CrudEntity
  {
    public CrudDetail Detail { get; set; }


    /// <summary> For creating a new Crud without an Id. </summary>
    public Crud(string department, string name) : base(department, name)
    {

    }

    /// <summary> For returning a new Crud. </summary>
    /// 
    public Crud(int id, CrudEntity entity, CrudDetail detail) : base(id, entity)
    {
      Detail = detail;
    }

    /// <summary> For returning an existing Crud. </summary>
    /// 
    public Crud(CrudEntity entity, CrudDetail detail) : base(entity)
    {
      Detail = detail;
    }

    /// <summary> Primarily for mocking libraries</summary>
    public Crud() { }

  }
}
