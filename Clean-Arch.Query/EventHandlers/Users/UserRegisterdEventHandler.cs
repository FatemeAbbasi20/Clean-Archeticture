using Clean_Arch.Domain.Users.Events;
using Clean_Arch.Domain.Users.Repository;
using Clean_Arch.Query.Models.Users.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Query.EventHandlers.Users
{
    public class UserRegisterdEventHandler : INotificationHandler<UserRegistered>
    {
        private readonly IUserRepository _writeRepository;
        private readonly IUserReadRepository   _readRepository;

        public UserRegisterdEventHandler(IUserRepository writeRepository, IUserReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task Handle(UserRegistered notification, CancellationToken cancellationToken)
        {
            var user =  await _writeRepository.GetbyEmail(notification.Email);
            await _readRepository.Insert(new Models.Users.UserReadModel()
            {
                Email= user.Email,Id=user.Id,PhoneNumber=user.PhoneNumber,Name=user.Name,Family=user.Family,CreationTime=user.CreationTime
            });
           
        }
    }
}
