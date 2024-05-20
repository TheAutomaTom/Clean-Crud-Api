namespace CCA.Core.Infra.EntityUtilities
{
	public abstract class Auditable
	{
		public int Id { get; set; }
		public string CreatedBy { get; set; } = string.Empty;
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public string? LastModifiedBy { get; set; }
		public DateTime? LastModifiedDate { get; set; }

	}
}
