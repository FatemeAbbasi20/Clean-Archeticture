using Clean_Arch.Infrastructure.Persistent.Memory;
using Clean_Arch.Query.Models.Products;
using Clean_Arch.Query.Models.Products.Repository;
using Clean_Arch.Query.Products.Dtos;
using Clean_Arch.Query.Products.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clean_Arch.Query.Products.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductListQuery, List<ProductReadModel>>
    {
        private readonly AppDbContext _context;

        private readonly IProductReadRepository _ReadRepository;
        public GetProductsQueryHandler(AppDbContext context, IProductReadRepository readRepository)
        {
            _context = context;
            _ReadRepository = readRepository;
        }
        //public  async Task<List<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        //{
        //    return await _context.Products.Include(d=>d.Images).Select(product=>ProductMapper.MaptoProductDto(product)).ToListAsync();
           
        //}
        public async Task<List<ProductReadModel>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return await _ReadRepository.GetAll();

        }
    }
}
