using Clean_Arch.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Domain.Users.Repository
{
    public interface IUserRepository
    {
        Task SaveChanges();
        Task<User> GetById(long id);
        void Add(User user);
        void Update(User user);
        bool UserIsExist(string Email);
        Task<User> GetbyEmail(string email);
    }
}
