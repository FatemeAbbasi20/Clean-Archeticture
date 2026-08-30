using Clean_Arch.Query.Shared.BaseRepository;
using MongoDB.Driver;

namespace Clean_Arch.Query.Models.Products.Repository
{
    public class ProductReadRepository : BaseReadRepository<ProductReadModel>, IProductReadRepository
    {
        public ProductReadRepository(IMongoClient client ) : base(client)
        {
            
        }
    }
}
