using ZZ.Core.Domain.Common;

namespace ZZ.Core.Domain.Models.Cruds.Repo
{
  public class CrudEntity : AuditableEntity
  {
    public int Id { get; set; }
    public string Location { get; set; }
    public string Contact { get; set; }

    /// <summary> Called when creating a completed Crud. </summary>
    public CrudEntity(int id, CrudEntity entity)
    {
      Id = id;
      Location = entity.Location;
      Contact = entity.Contact;
    }
    
    /// <summary> Called when creating a new Crud without an Id, yet. </summary>
    public CrudEntity(string location, string contact)
    {
      Location = location;
      Contact = contact;
    }

  }
}
