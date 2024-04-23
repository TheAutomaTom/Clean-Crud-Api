﻿namespace ZZ.Core.Domain.Common
{
  public abstract class AuditableEntity
  {
    public int Id { get; set; }
    public string CreatedBy { get; set; } = String.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }

  }
}
