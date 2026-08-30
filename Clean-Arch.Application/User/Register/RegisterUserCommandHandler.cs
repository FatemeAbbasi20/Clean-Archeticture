using Clean_Arch.Domain.Orders.Repository;
using Clean_Arch.Domain.Products.Repository;
using Clean_Arch.Domain.Users;
using Clean_Arch.Domain.Users.Events;
using Clean_Arch.Domain.Users.Repository;
using Clean_Arch.Domain.Users.ValueObjects;
using Clean_Arch.Domain.UsersAgg.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Application.Users.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, long>
    {
        private readonly IUserRepository _repository;
        private readonly IUserDomainService _domainService;
        private readonly IMediator _mediator;

        public RegisterUserCommandHandler(IUserRepository repository, IUserDomainService domainService, IMediator mediator)
        {
            _repository = repository;
            _domainService = domainService;
            _mediator = mediator;
        }

        public async Task<long> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
           var user= User.Register(request.Email, request.phoneNumber, _domainService);
              _repository.Add(user);
            await _repository.SaveChanges();
            foreach(var @event in user.DomainEvents)
            {
                await _mediator.Publish(@event);
            }
         
            return  user.Id;

        }
    }
}
