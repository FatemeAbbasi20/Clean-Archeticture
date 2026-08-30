using Clean_Arch.Domain.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Domain.OrdersAgg.Exceptions
{
    public class ProductNotFoundException:BaseDomainException
    {
        
        public ProductNotFoundException() :base("ProductNotFound")
        {
            
        }
    }
}
