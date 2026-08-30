using Clean_Arch.Domain.Users.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Application.Users.Register
{
    public record RegisterUserCommand(string Email,string phoneNumber):IRequest<long>;
    

     
     
    
}
