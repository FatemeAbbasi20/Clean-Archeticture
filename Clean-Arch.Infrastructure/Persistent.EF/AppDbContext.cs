using Clean_Arch.Domain.Orders;
using Clean_Arch.Domain.OrdersAgg;
using Clean_Arch.Domain.Products;
using Clean_Arch.Domain.ProductsAgg;
using Clean_Arch.Domain.Shared;
using Clean_Arch.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Infrastructure.Persistent.Memory
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
           
        }
       public DbSet<Product> Products { get; set; }
       public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().OwnsOne(c => c.Price, option =>
            {
                option.Property(d => d.RialValue).HasColumnName("RialPrice");
            });
            modelBuilder.Entity<Product>().OwnsOne(f => f.Price);
            modelBuilder.Entity<User>().OwnsOne(f => f.PhoneNumber);
            base.OnModelCreating(modelBuilder);
        }
        
        
    }
}
