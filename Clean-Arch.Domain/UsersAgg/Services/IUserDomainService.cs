using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Domain.UsersAgg.Services
{
    public interface IUserDomainService
    {
        bool EmailIsExist(string email);
    }
}
