using Clean_Arch.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Domain.OrdersAgg
{
    public class OrderItem:BaseEntity
    {
        public OrderItem()
        {
            
        }
        public OrderItem( long orderId, int count, Money price,long productId)
        {
            if (count < 1)
                throw new ArgumentOutOfRangeException();
            OrderId = orderId;
            Count = count;
            Price = price;
            ProductId = productId;
        }

        public long Id { get; private set; }
        public long OrderId { get; protected set; }
        public long ProductId { get; set; }
        public int Count { get; private set; }
        public Money  Price { get; private set; }
        



    }

}
