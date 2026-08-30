using Clean_Arch.Query.Models.Products;
using Clean_Arch.Query.Products.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Query.Products.GetProducts
{
    public class GetProductListQuery:IRequest<List<ProductReadModel>>
    {
       
    }
}
