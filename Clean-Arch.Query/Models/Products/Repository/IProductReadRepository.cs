using Clean_Arch.Domain.Products;
using Clean_Arch.Query.Shared.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Query.Models.Products.Repository
{
    public interface IProductReadRepository:IBaseReadRepository<ProductReadModel>
    {

    }
}
