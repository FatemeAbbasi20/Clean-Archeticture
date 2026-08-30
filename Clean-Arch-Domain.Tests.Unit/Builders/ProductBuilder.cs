using Clean_Arch.Domain.Products;
using Clean_Arch.Domain.ProductsAgg;
using Clean_Arch.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch_Domain.Tests.Unit.Builders
{
    public class ProductBuilder
    {
        private Money _money = new Money(1000);
        private string _title = "test1";
        private string _description = "rf";
        public Product Build()
        {
            return new Product(_money, _title,_description);
        }
        public ProductBuilder SetTitle(string title)
        {
            _title = title;
            return this;
        }
        public ProductBuilder SetMoney(Money money)
        {
            _money = money;
            return this;
        }

        
    }
}
