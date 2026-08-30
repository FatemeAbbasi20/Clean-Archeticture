using Clean_Arch.Domain.Orders;
using Clean_Arch.Domain.Orders.Repository;
using Clean_Arch.Domain.Products;
using Clean_Arch.Infrastructure.Persistent.Memory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Infrastructure.Persistent.Memory.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Order order)
        {
           _context.Orders.Add(order);
        }

         public  async Task<Order> GetById(long id)
        {
            return await _context.Orders.FirstOrDefaultAsync(f => f.Id == id);
        }
        

        public bool IsProductExisted(long productId)
        {
            return _context.Orders.Any(f => f.ProductId == productId);
        }

        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
        }

       
    }
}
