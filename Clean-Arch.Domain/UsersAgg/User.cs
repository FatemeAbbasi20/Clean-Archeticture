using Clean_Arch.Domain.Shared;
using Clean_Arch.Domain.Shared.Exceptions;
using Clean_Arch.Domain.Users.Events;
using Clean_Arch.Domain.Users.ValueObjects;
using Clean_Arch.Domain.UsersAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Domain.Users
{
    public class User:AggregateRoot
    {
        public User()
        {
            
        }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public User(string name,string family, string email, PhoneNumber phoneNumber,IUserDomainService domainService)
        {
            Guard(email);
            var emailISExist = domainService.EmailIsExist(email);
            if (emailISExist)
            {
                throw new InvalidDataDomainException("ایمیل وارد شده قبلا استفاده شده است");
            }
            Name = name;
            Family = family;
            Email = email;
            PhoneNumber = phoneNumber;

        }
    
       public static User Register(string email,string phoneNumber,IUserDomainService domainService)
        {
            var user = new User("", "", email,new PhoneNumber(phoneNumber), domainService);
            user.AddDomainEvent(new UserRegistered(user.Id,email));
            return user;
        }
        private void Guard(string Email)
        {
          
           NullOrEmptyDomainDataException.CheckString(Email,nameof(Email));
            
        }
    }
}
