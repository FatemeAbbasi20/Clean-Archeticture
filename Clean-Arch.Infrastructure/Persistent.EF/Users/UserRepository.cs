using Clean_Arch.Domain.Users;
using Clean_Arch.Domain.Users.Repository;
using Clean_Arch.Infrastructure.Persistent.Memory;
using Microsoft.EntityFrameworkCore;
namespace Clean_Arch.Infrastructure.Persistent.EF.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Add(user);
        }

        public async Task<User> GetById(long id)
        {
           return await _context.Users.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task SaveChanges()
        {
           await _context.SaveChangesAsync();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public bool UserIsExist(string Email)
        {
          return _context.Users.Any(s=>s.Email== Email);
        }
        public async Task<User> GetbyEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(f => f.Email == email);
        }
    }
}
