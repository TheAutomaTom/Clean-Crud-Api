using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCA.Core.Application.Interfaces.Persistence.Cruds;
using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Domain.Models.Cruds.Repo;
using CCA.Data.Persistence.Repositories.Common;
using Nest;

namespace CCA.Data.Persistence.Repositories
{
  public class CrudDetailsRepository : ElasticRepository<CrudDetail>, ICrudDetailsRepository
  {
    public CrudDetailsRepository(IElasticClient client) : base(client)
    {

    }

    /// <summary>
    /// Add CrudDetail from Elasticsearch to a list of CrudEntities
    /// </summary>
    /// <param name="entities">A list of CrudEntities used to find CrudDetails with matching IDs.</param>
    /// <returns>A list of Crud joining the provided entities with the newly found CrudDetails from Elasticsearch</returns>
    public async Task<IReadOnlyList<Crud>> Read(IEnumerable<CrudEntity> entities)
    {
      var results = new List<Crud>();
      foreach (var entity in entities)
      {
        var response = await _client.GetAsync<CrudDetail>(entity.Id);
        if (response.Source != null)
        {
          var detail = response.Source;
          results.Add(new Crud(entity, detail));
        }


      }
      return results;
    }


    public async Task<bool> Update(CrudDetail detail)
    {

      /* This is intended to be: 
          `UpdateRequest<TypeToUpdate, TypeOfDtoUsedToUpdate>(detail.Id)`
          {
            Doc = updateDtoParam
          };
      */

      return await base.Update(detail);


    }



  }
}
