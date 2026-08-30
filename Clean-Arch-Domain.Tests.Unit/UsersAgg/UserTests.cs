using Clean_Arch.Domain.Shared.Exceptions;
using Clean_Arch.Domain.Users;
using Clean_Arch.Domain.Users.ValueObjects;
using Clean_Arch.Domain.UsersAgg.Services;
using Clean_Arch_Domain.Tests.Unit.Builders;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch_Domain.Tests.Unit.UsersAgg
{
    public class UserTests
    {
        UserBuilder userBuilder;
        private readonly IUserDomainService _domainService;
        public UserTests()
        {
            userBuilder=new UserBuilder();
            var DomainService = Substitute.For<IUserDomainService>();
            _domainService = DomainService;
        }
        [Fact]
        public void Constructor_Should_Create_User()
        {
            _domainService.EmailIsExist("Ens").Returns(false);
            var result = userBuilder.SetName("name").SetFamily("family").SetEmail("email").SetPhoneBook(new PhoneNumber("11111111111")).
                SetDomainService(_domainService).Build();
            result.Name.Should().Be("name");
            result.Family.Should().Be("family");
            result.Email.Should().Be("email");
            result.PhoneNumber.Phone.Should().Be("11111111111");
        }

        [Fact]
        public void Register_Should_Create_User_And_Add_DomainEvent()
        {
           var userDomainService= Substitute.For<IUserDomainService>();
            _domainService.EmailIsExist("Ens").Returns(false);
            var user = User.Register("dd", "12365478956", userDomainService);
            user.DomainEvents.Should().HaveCount(1);
        }
        [Fact]
        public void Constructor_Should_throw_NullOrEmpty_Exception_When_email_Is_Null_Or_Empty()
        {
            var userDomainService = Substitute.For<IUserDomainService>();
            _domainService.EmailIsExist("Ens").Returns(false);
            var user = () => { userBuilder.SetEmail("").SetDomainService(_domainService).Build(); };
            user.Should().ThrowExactly< NullOrEmptyDomainDataException > ().WithMessage("email is null or empty");
        }
        [Fact]
        public void Constructor_Should_throw_InvalidDataDomainExeption_when_Email_Is_Exsist()
        {
            var userDomainService = Substitute.For<IUserDomainService>();
            _domainService.EmailIsExist("rf").Returns(true);
            var user = () => { userBuilder.SetEmail("rf").SetDomainService(_domainService).Build(); };
            user.Should().ThrowExactly<InvalidDataDomainException>().WithMessage("ایمیل وارد شده قبلا استفاده شده است");
            
            
        }
    }
}
