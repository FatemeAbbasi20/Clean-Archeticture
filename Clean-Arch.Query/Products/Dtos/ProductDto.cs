using Clean_Arch.Domain.ProductsAgg;
using Clean_Arch.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Query.Products.Dtos
{
    public class ProductDto
    {
        //public ProductDto(long id, Money price, string title, string description, List<ProductImage> images)
        //{
        //    ProductId = id;
        //    Price = price;
        //    Title = title;
        //    Description = description;
        //    Images = images;
        //}

        public long Id { get; set; }
        public Money Price { get;  set; }
        public string Title { get;  set; }
        public string Description { get;  set; }
        public List<ProductImage> Images { get;  set; }
    }
}
