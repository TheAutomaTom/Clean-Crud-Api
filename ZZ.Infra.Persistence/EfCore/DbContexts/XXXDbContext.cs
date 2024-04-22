using Microsoft.EntityFrameworkCore;
using ZZ.Core.Domain.Common;
using ZZ.Core.Domain.Entities;

namespace ZZ.Infra.Persistence.Sql.DbContexts
{
  public class XXXDbContext : DbContext
  {
    public XXXDbContext(DbContextOptions<XXXDbContext> options) : base(options)
    {
    }

    public DbSet<XXXEntity> XXXs { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(XXXDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
      foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
      {
        switch (entry.State)
        {

          case EntityState.Added:
            entry.Entity.CreatedDate = DateTime.Now;
            entry.Entity.CreatedBy = nameof(XXXRepository);
            entry.Entity.LastModifiedDate = entry.Entity.CreatedDate; // Why can't these be null? 
            entry.Entity.LastModifiedBy = entry.Entity.CreatedBy;     // Why can't these be null? 
            break;

          case EntityState.Modified:
            entry.Entity.LastModifiedDate = DateTime.Now;
            entry.Entity.LastModifiedBy = nameof(XXXRepository);
            break;

        }
      }
      return base.SaveChangesAsync(cancellationToken);
    }



  }
}
