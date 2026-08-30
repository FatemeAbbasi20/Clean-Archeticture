using Clean_Arch.Domain.Products.Repository;
using Clean_Arch.Domain.ProductsAgg.Events;
using Clean_Arch.Query.Models;
using Clean_Arch.Query.Models.Products;
using Clean_Arch.Query.Models.Products.Repository;
using MediatR;

namespace Clean_Arch.Query.EventHandlers.Products
{
    public class ProductEditedEventHandler : INotificationHandler<ProductEdited>
    {
        private readonly IProductRepository _writeRepository;
        private readonly IProductReadRepository _ReadRepository;

        public ProductEditedEventHandler(IProductRepository writeRepository, IProductReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _ReadRepository = readRepository;
        }

        public async Task Handle(ProductEdited notification, CancellationToken cancellationToken)
        {
            var product = await _writeRepository.GetById(notification.ProductId);
            await _ReadRepository.Update(new ProductReadModel()
            {
                Description = product.Description,
                Id = product.Id,
                Title = product.Title,
                Price = product.Price,
                Images = null
            });

        }
    }
}
