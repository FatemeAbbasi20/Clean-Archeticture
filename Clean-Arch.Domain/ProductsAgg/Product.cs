using Clean_Arch.Domain.ProductsAgg;
using Clean_Arch.Domain.ProductsAgg.Events;
using Clean_Arch.Domain.Shared;
using Clean_Arch.Domain.Shared.Exceptions;
using Clean_Arch.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Domain.Products
{
    public class Product:AggregateRoot
    {
        public Product()
        {
            
        }
        public Product(Money money, string title,string description)
        {
           Gurd( title);
            Price = money;
            Title = title;
            Description = description;
            Images = new List<ProductImage>();
            AddDomainEvent(new ProductCreated(Id,Title));
        }

        public Money Price { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public List<ProductImage> Images { get; private set; }
        public void Edit(Money price, string title,string description)
        {
            Gurd(title);
            Price = price;
            Title = title;
            Description=description;
            AddDomainEvent(new ProductEdited()
            {
                ProductId= Id,
                Name= Title
            });
        }
     
     private void Gurd(string title)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));


        }
        

        public void AddImage(string name)
        {
            Images.Add(new ProductImage(Id,name));

        }
        public void RemoveImage(long id)
        {
           var image=Images.FirstOrDefault(d=>d.Id==id);
            if (image == null)
            {
                throw new NullOrEmptyDomainDataException("image is not found");
            }
            Images.Remove(image);
        }
    }
}
