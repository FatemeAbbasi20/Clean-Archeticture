using Clean_Arch.Query.Shared.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Query.Models.Users.Repository
{
    public interface IUserReadRepository:IBaseReadRepository<UserReadModel>
    {
        Task<UserReadModel> GetUserByEmail(string email);
    }
}
