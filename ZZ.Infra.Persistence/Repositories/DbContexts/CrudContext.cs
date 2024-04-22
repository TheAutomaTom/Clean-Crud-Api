using Microsoft.EntityFrameworkCore;
using ZZ.Core.Domain.Common;
using ZZ.Infra.Persistence.EfCore;
using ZZ.Infra.Persistence.EfCore.DbContexts;
using ZZ.Core.Domain.Models.Cruds.Repo;

namespace ZZ.Infra.Persistence.EfCore.DbContexts
{
  public class CrudContext : DbContext
  {
    public CrudContext(DbContextOptions<CrudContext> options) : base(options)
    {
    }

    public DbSet<CrudEntity> Cruds { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(CrudContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
      foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
      {
        switch (entry.State)
        {

          case EntityState.Added:
            entry.Entity.CreatedDate = DateTime.Now;
            entry.Entity.CreatedBy = nameof(CrudRepository);
            entry.Entity.LastModifiedDate = entry.Entity.CreatedDate; // Why can't these be null? 
            entry.Entity.LastModifiedBy = entry.Entity.CreatedBy;     // Why can't these be null? 
            break;

          case EntityState.Modified:
            entry.Entity.LastModifiedDate = DateTime.Now;
            entry.Entity.LastModifiedBy = nameof(CrudRepository);
            break;

        }
      }
      return base.SaveChangesAsync(cancellationToken);
    }



  }
}
