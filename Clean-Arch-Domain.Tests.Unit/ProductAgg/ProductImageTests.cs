using Clean_Arch.Domain.ProductsAgg;
using Clean_Arch.Domain.Shared.Exceptions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch_Domain.Tests.Unit.ProductAgg
{
    public class ProductImageTests
    {
     
        
        [Fact]
        public void ProductImage_Should_CreateProductImage()
        {
            
            var productImages = new ProductImage(1,"s.jpg");
            productImages.ImageName.Should().Be("s.jpg");
        }
        [Fact]
        public void ProductImage_Should_ThrowNullOrEmpty_Exception_When_ImageName_is_NullOrEmpty()
        {
            var result = (() => { new ProductImage(1, ""); });
            result.Should().ThrowExactly<NullOrEmptyDomainDataException>().WithMessage("imageName is null or empty");
        }
    }
}
