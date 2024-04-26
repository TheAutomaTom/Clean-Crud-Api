using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CCA.Core.Domain.Models.Cruds.Repo;

namespace CCA.Infra.Persistence.Repositories.DbContexts
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
