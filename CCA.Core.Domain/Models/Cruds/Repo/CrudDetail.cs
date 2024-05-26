using CCA.Core.Infra.Models.Common;

namespace CCA.Core.Domain.Models.Cruds.Repo
{
	public class CrudDetail : AuditableEntity
  {
    public int Id { get; set; }
    public string Description { get; set; }
    public IEnumerable<string> Tags { get; set; }

    public CrudDetail(int id, string desc, IEnumerable<string> tags)
    {
      Id = id;
      Description = desc;
      Tags = tags;
    }

    public CrudDetail(CrudDetail cd) 
    { 
      Id = cd.Id;
      Description = cd.Description;
      Tags = cd.Tags;
    }

    /// <summary> Primarily for mocking libraries  </summary>
    public CrudDetail() { }

  }
}
