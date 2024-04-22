namespace ZZ.Core.Domain.Common
{
  public abstract class AuditableEntity
  {
    public int Id { get; set; }
    public string CreatedBy { get; set; } = nameof(ZZ);
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public string? LastModifiedBy { get; set; } = nameof(ZZ);
    public DateTime? LastModifiedDate { get; set; } = DateTime.Now;

  }
}
