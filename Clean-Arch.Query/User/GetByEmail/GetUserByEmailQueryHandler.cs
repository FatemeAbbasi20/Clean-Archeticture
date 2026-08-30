using Clean_Arch.Query.Models.Users;
using Clean_Arch.Query.Models.Users.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Query.User.GetByEmail
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserReadModel>
    {
        private readonly IUserReadRepository _repository;
        

        public GetUserByEmailQueryHandler(IUserReadRepository readRepository)
        {
            _repository = readRepository;
        }

        public Task<UserReadModel> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
           return  _repository.GetUserByEmail(request.Email);

        } 
    }
}
