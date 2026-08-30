using Clean_Arch.Domain.Users;
using Clean_Arch.Domain.Users.ValueObjects;
using Clean_Arch.Domain.UsersAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch_Domain.Tests.Unit.Builders
{
    public class UserBuilder
    {
        private string _name = "d";
        private string _family = "dd";
        private string _email = "ddd";
        private IUserDomainService _domainService;
        private PhoneNumber _phoneBooks = new PhoneNumber("01234569874");
       
        public User Build()
        {
            return new User(_name,_family,_email,_phoneBooks, _domainService);
        }
        public UserBuilder SetName(string name)
        {
            _name = name;
            return this;
        }
        public UserBuilder SetFamily(string family)
        {
            _family = family;
            return this;
        }
        public UserBuilder SetEmail(string email)
        {
           _email=email;
            return this;
        }
        public UserBuilder SetPhoneBook(PhoneNumber phoneBooks)
        {
            _phoneBooks = phoneBooks;
            return this;
        }
        public UserBuilder SetDomainService(IUserDomainService domainservice)
        {
           _domainService=domainservice;
            return this;
        }


    }
}
