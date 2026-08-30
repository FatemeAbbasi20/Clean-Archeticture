using Clean_Arch.Domain.Products.Repository;
using Clean_Arch.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Application.Products.Edit
{
    public class EditProductCommandHandler : IRequestHandler<EditProductCommand>
    {
        private IProductRepository _repository;
        private readonly IMediator _mediator;
        public EditProductCommandHandler(IProductRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }
        public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(request.Id);
            product.Edit(new Money(request.Price), request.Title, request.Description);
            _repository.Update(product);
           await _repository.SaveChange();
            foreach (var @event in product.DomainEvents)
            {
                await _mediator.Publish(@event);
            }
            return Unit.Value;
        }
    }
}
