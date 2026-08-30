using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Application.Products.Create
{
    public class CreateProductCommand:IRequest<long>
    {
        public CreateProductCommand(int price, string title, string description)
        {
            Price = price;
            Title = title;
            Description = description;
        }

        public int Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
