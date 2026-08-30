using Clean_Arch.Infrastructure.Persistent.Memory;
using Clean_Arch.Query.Models.Products;
using Clean_Arch.Query.Models.Products.Repository;
using Clean_Arch.Query.Products.Dtos;
using Clean_Arch.Query.Products.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Query.Products.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductReadModel>
    {
        private readonly AppDbContext _context;
        private readonly IProductReadRepository _ReadRepository;
        public GetProductByIdQueryHandler(AppDbContext context, IProductReadRepository readRepository)
        {
            _context = context;
            _ReadRepository = readRepository;
        }
        //public async Task<ProductReadModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        //{
        //    var product = await _context.Products.FirstOrDefaultAsync(s => s.Id == request.ProductId);
        //    return ProductMapper.MaptoProductDto(product);

        //}
        public async Task<ProductReadModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _ReadRepository.GetById(request.ProductId);


        }
    }
}
