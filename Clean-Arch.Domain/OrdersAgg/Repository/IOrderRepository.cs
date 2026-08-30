using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Domain.Orders.Repository
{
    public interface IOrderRepository
    {
      
        Task <Order> GetById(long id);
        void Add(Order order);
        void Update(Order order);
        Task SaveChange();
        bool IsProductExisted(long productId);

    }
}
