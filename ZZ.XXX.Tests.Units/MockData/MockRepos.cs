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

      var cruds = faker.Generate(10);

      var repo = new Mock<ICrudRepository>();

      // Spec each method you want access to

      repo.Setup(repo => repo.ReadAll()).ReturnsAsync(
        cruds.Select(e => new CrudEntity(e.Id, e.Department, e.Name)).ToList()
        );

      repo.Setup(repo => repo.ReadById(It.IsAny<int>())).ReturnsAsync(
        (int id) => cruds.FirstOrDefault(e => e.Id == id)
        );

      repo.Setup(repo => repo.Create(It.IsAny<CrudEntity>())).ReturnsAsync(
        (CrudEntity entity) => { 
          var newEntity = new CrudEntity(entity.Id, entity.Department, entity.Name);
          cruds.Add(new Crud(newEntity.Id, newEntity, null));
          return newEntity.Id;
      });

      //repo.Setup(repo => repo.Update(It.IsAny<CrudEntity>())).ReturnsAsync((CrudEntity entity) => entity.Id);

      //repo.Setup(repo => repo.Delete(It.IsAny<CrudEntity>())).ReturnsAsync((CrudEntity entity) => entity.Id);

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

      // Spec each method you want access to
      repo.Setup(repo => repo.ReadAll()).ReturnsAsync(details);

      repo.Setup(repo => repo.ReadById(It.IsAny<int>()))
        .ReturnsAsync((int id) => details.FirstOrDefault(e => e.Id == id));

      repo.Setup(repo => repo.Create(It.IsAny<CrudDetail>())).ReturnsAsync((CrudDetail entity) => entity.Id);

      repo.Setup(repo => repo.Update(It.IsAny<CrudDetail>())).ReturnsAsync((CrudDetail entity) => entity.Id);

      repo.Setup(repo => repo.Delete(It.IsAny<CrudDetail>())).ReturnsAsync((CrudDetail entity) => entity.Id);

      return repo;
    }


  }
}
