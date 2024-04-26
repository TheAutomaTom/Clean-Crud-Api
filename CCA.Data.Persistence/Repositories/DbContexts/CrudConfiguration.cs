using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CCA.Core.Domain.Models.Cruds.Repo;

namespace CCA.Data.Persistence.Config.DbContexts
{
  public class CrudConfiguration : IEntityTypeConfiguration<CrudEntity>
  {
    public void Configure(EntityTypeBuilder<CrudEntity> builder)
    {
      builder.HasKey(e => e.Id);
      builder.Property(e => e.Id).ValueGeneratedOnAdd();
    }
  }
}
