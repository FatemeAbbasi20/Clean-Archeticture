using Clean_Arch.Domain.OrdersAgg;
using Clean_Arch.Domain.OrdersAgg.Events;
using Clean_Arch.Domain.OrdersAgg.Exceptions;
using Clean_Arch.Domain.OrdersAgg.Services;
using Clean_Arch.Domain.Shared;
using Clean_Arch.Domain.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Domain.Orders
{
    public class Order:AggregateRoot
    {
        public Order()
        {
            
        }
        public long UserId { get; private set; }
        public long ProductId { get; private set; }
        public int TotlaCount { get; private set; }
        public int TotlaPrice => Items.Sum(s => s.Price.RialValue);
        public bool IsFinal { get; set; }
        public DateTime FinalDate { get; set; }
        public ICollection<OrderItem>   Items { get; private set; }
        public Order(long userId)
        {
           UserId = userId;
           Items= new List<OrderItem>();
        }
        //public void IncreaseCount(int count)
        //{
        //    if(count<1)
        //        throw new ArgumentOutOfRangeException();
        //    TotlaCount += count;
        //}
        public void Finally()
        {
            IsFinal = true;
            FinalDate= DateTime.Now;
            AddDomainEvent(new OrderFinalized(UserId, Id));
        }

       public void AddItem(long productId,int Count,Money Price,IOrderDomainService domainService)
        {
            if (domainService.IsProductNotExisted(productId))
            {
                throw new ProductNotFoundException();
            }
            if (Items.Any(d => d.ProductId == productId))
                return;
            Items.Add(new OrderItem(Id, Count, Price,productId));
            TotlaCount += Count;
        }
        public void RemoveItem(long ProductId)
        {
            var item=Items.FirstOrDefault(d=>d.ProductId == ProductId);
            if (item == null)
            {
                throw new ProductNotFoundException();
            }
            Items.Remove(item);
            TotlaCount-= item.Count;
        }
    }
}
