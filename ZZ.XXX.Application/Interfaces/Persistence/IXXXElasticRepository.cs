using ZZ.XXX.Domain.Dtos.Elastic;

namespace ZZ.XXX.Application.Interfaces.Persistence
{
  public interface IXXXElasticRepository
  {
    Task<string> Create(XXXEls document);
    Task<IEnumerable<XXXEls>> GetAll();
  }
}
