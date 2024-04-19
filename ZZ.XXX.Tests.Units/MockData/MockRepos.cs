using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using ZZ.XXX.Application.Interfaces.Persistence;
using ZZ.XXX.Domain.Entities;

namespace ZZ.XXX.Tests.Units.MockData
{
  public class MockRepos
  {
    //public static IAsyncRepository<XXXEntity> GetXXXRepo()
    //{
    //  int id = 0;
    //  var faker = new Bogus.Faker<XXXEntity>()
    //    .RuleFor(o => o.Id, f => ++id)
    //    .RuleFor(o => o.Name, f => f.Person.FirstName)
    //    .RuleFor(o => o.Description, f => f.Lorem.Sentence());

    //  var data = faker.Generate(10);

    //  var fixture = new Fixture();

    //  var repo = fixture.Create<IXXXRepository>();

    //  foreach(var fake in data)
    //  {
    //    repo.Create(fake);
    //  }

    //  return repo;
    //}  

    public static Mock<IAsyncRepository<XXXEntity>> GetXXXRepository()
    {

      int id = 0;
      var faker = new Bogus.Faker<XXXEntity>()
        .RuleFor(o => o.Id, f => ++id)
        .RuleFor(o => o.Name, f => f.Person.FirstName)
        .RuleFor(o => o.Description, f => f.Lorem.Sentence());

      var data = faker.Generate(10);

      var repo = new Mock<IAsyncRepository<XXXEntity>>();
      repo.Setup(repo => repo.ReadAll()).ReturnsAsync(data);

      repo.Setup(repo => repo.Create(It.IsAny<XXXEntity>())).ReturnsAsync(1);

      return repo;
    }


  }
  }
