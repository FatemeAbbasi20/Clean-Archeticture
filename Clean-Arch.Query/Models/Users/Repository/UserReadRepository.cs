using Clean_Arch.Query.Shared.BaseRepository;
using MongoDB.Driver;

namespace Clean_Arch.Query.Models.Users.Repository
{
    public class UserReadRepository : BaseReadRepository<UserReadModel>, IUserReadRepository
    {
         
        public UserReadRepository(IMongoClient client) : base(client)
        {
            
        }
        public async Task <UserReadModel> GetUserByEmail( string email)
        {
          return await _collection.Find(s => s.Email == email).FirstOrDefaultAsync();

        }
       
    }
}
