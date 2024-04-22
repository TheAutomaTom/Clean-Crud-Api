using Bogus;
using Microsoft.EntityFrameworkCore;
using ZZ.Infra.Persistence.EfCore.DbContexts;
using ZZ.Core.Domain.Models.Cruds.Repo;

namespace ZZ.XXX.Tests.Integration.Persistence.InMemory
{
  public class CrudContextTests
  {
    readonly CrudContext _context;

    public CrudContextTests()
    {
      var contextOptions = new DbContextOptionsBuilder<CrudContext>()
        .UseInMemoryDatabase(Guid.NewGuid().ToString())
        .Options;

      _context = new CrudContext(contextOptions);


    }


    [Fact]
    public async void SaveChangesAsync_WhenEntityAdded_ExpectAuditFieldsSet()
    {
      var faker = new Faker<CrudEntity>()
        .RuleFor(o => o.Contact, f => f.Person.FirstName)
        .RuleFor(o => o.Location, f => f.Name.JobTitle());

      var entity = faker.Generate(1).First();

      _context.Cruds.Add(entity);
      await _context.SaveChangesAsync();

      Assert.NotEqual(DateTime.MinValue, entity.CreatedDate);


      var expectedName = nameof(ZZ.Infra.Persistence.EfCore.CrudRepository);

      Assert.Equal(expectedName, entity.CreatedBy);
    }
  }
}
