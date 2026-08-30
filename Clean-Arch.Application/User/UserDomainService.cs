using Clean_Arch.Domain.Users.Repository;
using Clean_Arch.Domain.UsersAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Application.Users
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _repository;

        public UserDomainService(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool EmailIsExist(string email)
        {
           return _repository.UserIsExist(email);
        }
    }
}
