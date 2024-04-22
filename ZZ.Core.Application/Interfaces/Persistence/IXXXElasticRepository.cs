using ZZ.Core.Domain._Deprecated.Elastic;

namespace ZZ.Core.Application.Interfaces.Persistence
{
  public interface IXXXElasticRepository
  {
    Task<string> Create(XXXEls document);
    Task<IEnumerable<XXXEls>> GetAll();
  }
}
