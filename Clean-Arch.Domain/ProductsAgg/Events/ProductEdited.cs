using Clean_Arch.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Domain.ProductsAgg.Events
{
    public class ProductEdited:BaseDoaminEvent
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
    }
}
