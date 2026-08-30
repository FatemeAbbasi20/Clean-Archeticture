using Clean_Arch.Query.Models.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Query.User.GetByEmail
{
    public record GetUserByEmailQuery(string Email):IRequest<UserReadModel>;
    
}
