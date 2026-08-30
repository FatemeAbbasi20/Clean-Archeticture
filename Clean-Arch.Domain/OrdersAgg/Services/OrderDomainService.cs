using Clean_Arch.Domain.Orders.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Domain.OrdersAgg.Services
{
    public class OrderDomainService : IOrderDomainService
    {
        private readonly IOrderRepository _orderRepository;
        public bool IsProductNotExisted(long productId)
        {
            var productIsExsist=_orderRepository.IsProductExisted(productId);
            return !productIsExsist;
        }
    }
}
