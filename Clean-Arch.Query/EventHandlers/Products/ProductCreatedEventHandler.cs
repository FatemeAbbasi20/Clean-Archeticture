using Clean_Arch.Domain.Products.Repository;
using Clean_Arch.Domain.ProductsAgg.Events;
using Clean_Arch.Query.Models;
using Clean_Arch.Query.Models.Products;
using Clean_Arch.Query.Models.Products.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Query.EventHandlers
{
    public class ProductCreatedEventHandler : INotificationHandler<ProductCreated>
    {
        private readonly IProductRepository _writeRepository;
        private readonly IProductReadRepository _ReadRepository;

        public ProductCreatedEventHandler(IProductRepository writeRepository, IProductReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _ReadRepository = readRepository;
        }

        public async Task Handle(ProductCreated notification, CancellationToken cancellationToken)
        {
           var product= await _writeRepository.GetById(notification.Id);
           await  _ReadRepository.Insert(new ProductReadModel(){
                Description=product.Description,Id=product.Id,Title=product.Title,
                Price=product.Price,Images=null
            });
          
        }
    }
}
