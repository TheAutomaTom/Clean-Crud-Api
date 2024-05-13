namespace CCA.Core.Domain.Models.Cruds.Responses
{
  /// <summary> This is used in the Dto for any new or altered Crud. </summary>
  public class CrudUpdate
  {
    public int Id { get; set; }

    // Entity
    public string Name { get; set; }
    public string Department { get; set; }

    // Detail
    public string Description { get; set; }
    public IEnumerable<string> Tags { get; set; }


  }
}
