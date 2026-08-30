using Clean_Arch.Domain.Orders;
using Clean_Arch.Domain.Products;
using Clean_Arch.Domain.Products.Repository;
using Clean_Arch.Domain.ProductsAgg.Events;
using Clean_Arch.Domain.Shared;
using Clean_Arch.Domain.Shared.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Application.Products.Create
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand,long>
    {
        private IProductRepository _repository;
        private readonly IMediator _mediator;
        public CreateProductHandler(IProductRepository repository,IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }
        public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
          //  var validator=new CreateProductCommandValidator();
          //var checker=  validator.Validate(request);
          //  if (!checker.IsValid)
          //  {
          //      var stringBuilder = new StringBuilder();
          //      foreach(var error in checker.Errors)
          //      {
          //          stringBuilder.AppendLine(error.ErrorMessage);
          //      }
          //      throw new InvalidDataDomainException(stringBuilder.ToString());
          //  }
            var product = new Product(new Money(request.Price), request.Title, request.Description);
            _repository.Add(product);
            await _repository.SaveChange();
            await _mediator.Publish(new ProductCreated(product.Id,product.Title));
            return  product.Id;
          
        }

    }
}
