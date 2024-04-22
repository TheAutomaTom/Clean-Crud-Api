using System.Reflection.Emit;
using Bogus;
using Microsoft.EntityFrameworkCore;
using ZZ.Core.Domain.Common;
using ZZ.Core.Domain.Models.Cruds.Repo;
using ZZ.Infra.Persistence.Repositories;
using ZZ.Infra.Persistence.Repositories.DbContexts;

namespace ZZ.Infra.Persistence.Repositories.DbContexts
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


    protected override void OnModelCreating(ModelBuilder model)
    {

      model.ApplyConfigurationsFromAssembly(typeof(CrudContext).Assembly);

      model.Entity<CrudEntity>(entity =>
      {
        entity.HasKey(e => e.Id);

      });

      var subscriberFaker = new Faker<CrudEntity>()
        .RuleFor(s => s.Name, f => f.Commerce.ProductName())
        .RuleFor(s => s.Department, f => f.Commerce.Department());
      var fakes = subscriberFaker.Generate(10);

      var i = 0;
      foreach (var fake in fakes)
      {
        fake.Id = --i;
      }

      model.Entity<CrudEntity>().HasData(fakes);

      base.OnModelCreating(model);
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
            entry.Entity.LastModifiedDate = null;
            entry.Entity.LastModifiedBy = null;
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
