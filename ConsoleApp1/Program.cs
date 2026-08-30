

using Clean_Arch.Domain.Shared;
using Clean_Arch.Domain.Users;
using Clean_Arch.Domain.Users.ValueObjects;

var User1 = new User("rstg", "rtg","j", new PhoneBook(new PhoneNumber("12365478965"), new PhoneNumber("12378965"), new PhoneNumber("12365478965")));

var User2 = new User("rstg", "rtg","k", new PhoneBook(new PhoneNumber("12578965412"), new PhoneNumber("12365478965"), new PhoneNumber("12365478965")));
//Console.WriteLine(User1.PhoneBooks.Fax2==User2.PhoneBooks.Fax1);