using Clean_Arch.Domain.OrdersAgg;
using Clean_Arch.Domain.Shared;
using Clean_Arch.Domain.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Domain.ProductsAgg
{
    public class ProductImage:BaseEntity
    {
        public ProductImage()
        {
            
        }
        public ProductImage(long ProductId, string imageName)
        { NullOrEmptyDomainDataException.CheckString(imageName,nameof(imageName));
            ImageName = imageName;
         
        }

        public string ImageName { get; private set; }
        public long ProductId { get; private set; }

       
    }
}
