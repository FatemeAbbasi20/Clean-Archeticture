using Clean_Arch.Domain.ProductsAgg;
using Clean_Arch.Domain.Shared;
using Clean_Arch.Query.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Query.Models.Products
{
    public class ProductReadModel:BaseReadModel
    {
        public Money Price { get;  set; }
        public string Title { get;  set; }
        public string Description { get;  set; }
        public ICollection<ProductImage> Images { get;  set; }
        public DateTime CreationTime { get; set; }
    }
}
