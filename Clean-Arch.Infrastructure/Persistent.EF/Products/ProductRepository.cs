using Clean_Arch.Domain.Products;
using Clean_Arch.Domain.Products.Repository;
using Clean_Arch.Infrastructure.Persistent.Memory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Infrastructure.Persistent.Memory.Products
{
    public class ProductRepository : IProductRepository
    {  private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public async Task<Product> GetById(long id)
        {
            return await _context.Products.FirstOrDefaultAsync(e => e.Id == id);
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task  SaveChange()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Product product)
        {
           _context.Products.Update(product);
        }
    }
}
