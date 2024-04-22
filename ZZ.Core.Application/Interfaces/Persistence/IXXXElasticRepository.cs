using ZZ.Core.Domain.Dtos.Elastic;

namespace ZZ.Core.Application.Interfaces.Persistence
{
  public interface IXXXElasticRepository
  {
    Task<string> Create(XXXEls document);
    Task<IEnumerable<XXXEls>> GetAll();
  }
}
