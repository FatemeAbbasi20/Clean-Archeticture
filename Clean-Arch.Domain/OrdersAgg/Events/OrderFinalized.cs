using Clean_Arch.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Domain.OrdersAgg.Events
{
    public class OrderFinalized:BaseDoaminEvent
    {
        public OrderFinalized(long userId, long orderId)
        {
            UserId = userId;
            OrderId = orderId;
        }

        public long UserId { get; private set; }
        public long OrderId { get; private set; }
    }
}
