using MongoDB.Driver;

namespace Clean_Arch.Query.Shared.BaseRepository
{
    public class BaseReadRepository<TEntity>:IBaseReadRepository<TEntity> where TEntity : BaseReadModel
    {
  
        public readonly IMongoCollection<TEntity> _collection;
        public BaseReadRepository(IMongoClient client)
        {
            var dataBase = client.GetDatabase("Clean-Arch");
            _collection = dataBase.GetCollection<TEntity>(typeof(TEntity).Name);
        }
        public async Task Insert(TEntity entity)
        {
           await _collection.InsertOneAsync(entity);
        }

        public async Task Delete(long id)
        {
           await _collection.DeleteOneAsync(s => id == id);
        }
        public async Task <List<TEntity>>GetAll()
        {
            var res= _collection.Find(_ => true);
            return res.ToList();
        }

        public async Task<TEntity> GetById(long id)
        {

            var res = await _collection.FindAsync(d => d.Id == id);
            return res.FirstOrDefault();

        }
        public async Task Update(TEntity entity)
        {
          await  _collection.ReplaceOneAsync(t=>t.Id==entity.Id,entity);
        }

    }
}
