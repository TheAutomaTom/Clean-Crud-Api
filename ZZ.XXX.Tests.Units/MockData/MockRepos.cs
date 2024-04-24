using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Bogus;
using Moq;
using ZZ.Core.Application.Interfaces.Persistence;
using ZZ.Core.Domain.Models.Cruds;
using ZZ.Core.Domain.Models.Cruds.Repo;

namespace ZZ.XXX.Tests.Units.MockData
{
  public class MockRepos
  {

    readonly static Random _rando = new Random();

    public static Mock<ICrudRepository> MockCrudRepository()
    {

      int id = 0;
      var faker = new Faker<Crud>()
        .RuleFor(s => s.Name, f => f.Commerce.ProductName())
        .RuleFor(s => s.Department, f => f.Commerce.Department());
      var fakes = faker.Generate(10);

      var data = faker.Generate(10);

      var repo = new Mock<ICrudRepository>();
      repo.Setup(repo => repo.ReadAll()).ReturnsAsync(data);

      repo.Setup(repo => repo.Create(It.IsAny<CrudEntity>())).ReturnsAsync(1);

      return repo;
    }
    

    public static Mock<ICrudDetailRepository> MockCrudDetailRepository(Mock<ICrudRepository> crudRepo)
    {

      var entities = crudRepo.Object.ReadAll().Result.ToList();

      var faker = new Faker<CrudDetail>()
        .RuleFor(x => x.Id, 0)
        .RuleFor(x => x.Description, f => f.Lorem.Lines(_rando.Next(3,15)))
        .RuleFor(x => x.Tags, f => f.Lorem.Words(_rando.Next(1, 8)));


      var details = faker.Generate(entities.Count);

      for (int i = 0; i < entities.Count; i++)
      {
        details[i].Id = entities[i].Id;
      }

      var repo = new Mock<ICrudDetailRepository>();
      repo.Setup(repo => repo.ReadAll()).ReturnsAsync(details);

      repo.Setup(repo => repo.Create(It.IsAny<CrudDetail>())).ReturnsAsync(1);

      return repo;
    }


  }
}
