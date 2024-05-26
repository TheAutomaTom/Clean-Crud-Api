namespace CCA.Core.Infra.Models.Common
{
	public abstract class AuditableEntity
	{
		public int Id { get; set; }
		public string CreatedBy { get; set; } = string.Empty;
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public string? LastModifiedBy { get; set; }
		public DateTime? LastModifiedDate { get; set; }

	}
}
