using Clean_Arch.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Domain.ProductsAgg.Events
{
    public class ProductCreated: BaseDoaminEvent
    {
        public ProductCreated(long id, string title)
        {
            Id = id;
            Title = title;
        }

        public long Id { get; set; }
        public string Title { get; set; }
    }
}
