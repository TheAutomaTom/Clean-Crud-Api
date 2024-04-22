using Bogus;
using Microsoft.EntityFrameworkCore;
using ZZ.Core.Domain.Models.Cruds.Repo;
using ZZ.Infra.Persistence.Repositories.DbContexts;

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
        .RuleFor(o => o.Name, f => f.Person.FirstName)
        .RuleFor(o => o.Department, f => f.Name.JobTitle());

      var entity = faker.Generate(1).First();

      _context.Cruds.Add(entity);
      await _context.SaveChangesAsync();

      Assert.NotEqual(DateTime.MinValue, entity.CreatedDate);


      var expectedName = nameof(ZZ.Infra.Persistence.Repositories.CrudRepository);

      Assert.Equal(expectedName, entity.CreatedBy);
    }
  }
}
