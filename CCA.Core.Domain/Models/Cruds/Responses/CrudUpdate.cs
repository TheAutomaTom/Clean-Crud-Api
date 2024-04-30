namespace CCA.Core.Domain.Models.Cruds.Responses
{
  public class CrudUpdate
  {    
    // Common
    public int Id { get; set; }

    // Entity
    public string Name { get; set; }
    public string Department { get; set; }

    // Detail
    public string Description { get; set; }
    public IEnumerable<string> Tags { get; set; }


  }
}
