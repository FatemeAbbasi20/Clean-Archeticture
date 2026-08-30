using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Query.Shared.BaseRepository
{
    public interface IBaseReadRepository<TEntity>where TEntity : BaseReadModel
    {
 

        Task Insert(TEntity entity);
       Task Update(TEntity entity);
        Task<TEntity> GetById(long id);
       Task<List<TEntity>> GetAll();
         Task Delete(long id);

    }
}
