using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZZ.Core.Domain.Models.Cruds.Repo;

namespace ZZ.Infra.Persistence.EfCore.DbContexts
{
  public class CrudConfiguration : IEntityTypeConfiguration<CrudEntity>
  {
    public void Configure(EntityTypeBuilder<CrudEntity> builder)
    {
      builder.HasKey(e => e.Id);
      builder.Property(e => e.Id).ValueGeneratedOnAdd();
      builder.Property(e => e.CreatedDate).IsRequired();
      builder.Property(e => e.CreatedBy).IsRequired();
      builder.Property(e => e.LastModifiedDate).IsRequired();
      builder.Property(e => e.LastModifiedBy).IsRequired();
    }
  }
}
