using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Microsoft.EntityFrameworkCore;
using ZZ.Core.Domain.Entities;
using ZZ.Infra.Persistence.DbContexts;

namespace ZZ.XXX.Tests.Integration.Persistence.InMemory
{
  public class XXXDbContextTests
  {
    readonly XXXDbContext _context;

    public XXXDbContextTests()
    {
      var contextOptions = new DbContextOptionsBuilder<XXXDbContext>()
        .UseInMemoryDatabase(Guid.NewGuid().ToString())
        .Options;

      _context = new XXXDbContext(contextOptions);


    }


    [Fact]
    public async void SaveChangesAsync_WhenEntityAdded_ExpectAuditFieldsSet()
    {
      var faker = new Faker<XXXEntity>()
        .RuleFor(o => o.Name, f => f.Person.FirstName)
        .RuleFor(o => o.Description, f => f.Lorem.Sentence());

      var entity = faker.Generate(1).First();

      _context.XXXs.Add(entity);
      await _context.SaveChangesAsync();

      Assert.NotEqual(DateTime.MinValue, entity.CreatedDate);


      var expectedName = nameof(ZZ.Infra.Persistence.Repositories.XXXRepository);

      Assert.Equal(expectedName, entity.CreatedBy);
    }
  }
}
