using Clean_Arch.Domain.Products;
using Clean_Arch.Query.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Clean_Arch.Query.Products.Mappers
{
    public class ProductMapper
    {
        public static ProductDto MaptoProductDto(Product product)
        {
            if (product == null)
                return null;
            return new ProductDto()
            { 
                Description = product.Description,
                Id = product.Id,
                Images = product.Images,
                Title  = product.Title,
                Price = product.Price,
              
            };
        }
    }
}
