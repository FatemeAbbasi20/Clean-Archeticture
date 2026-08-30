using Clean_Arch.Domain.Products;
using Clean_Arch.Domain.Shared;
using Clean_Arch.Domain.Shared.Exceptions;
using Clean_Arch_Domain.Tests.Unit.Builders;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch_Domain.Tests.Unit.ProductAgg
{
    public class ProductTests
    {
       private ProductBuilder productBuilder;
        public ProductTests()
        {
            productBuilder = new ProductBuilder();
        }
        [Fact]
        public void Product_Should_Create_Product_When_Data_Is_Valid()
        {
            var result=productBuilder.SetTitle("Book").SetMoney(new Money(100)).Build();
            result.Title.Should().Be("Book");
        }
        [Fact]
        public void Product_Should_Throw_NullOrEmptyException_When_Title_Is_NullOrEmpty()
        {
            var result = (() =>
            {
                productBuilder.SetTitle("").Build();
            });
            result.Should().ThrowExactly<NullOrEmptyDomainDataException>().WithMessage("title is null or empty");
        }
        [Fact]
        public void Edit_Should_Update_Product_When_Data_Is_Ok()
        { //arrange
            var product = productBuilder.SetTitle("Book").SetMoney(new Money(1000)).Build();
            //act
            product.Edit(new Money(1205), "LapTop","dd");
            //assert
            product.Title.Should().Be("LapTop");
            product.Price.RialValue.Should().Be(1205);
        }
        [Fact]
        public void Edit_Should_ThrowNullOremptyException_When_Title_Is_NUllOREmpty()
        {
            //arrange
            var product = productBuilder.SetTitle("rg").SetMoney(new Money(1000)).Build();
            //act
            var action = (() => {
                product.Edit(new Money(120),"","dd");
            });
            //assert
            action.Should().ThrowExactly<NullOrEmptyDomainDataException>();

        }
        [Fact]
        public void AddImage_Should_AddImage_To_Product()
        {
            //arrange
            var product = productBuilder.SetTitle("rg").SetMoney(new Money(1000)).Build();
            //act
            product.AddImage("gt");
            //assert
            product.Images.Should().HaveCount(1);
        }
       
        [Fact]
        public void RemoveImage_Should_RemoveImage_From_Product()
        {
            //arrange
            var product = productBuilder.SetTitle("rg").SetMoney(new Money(1000)).Build();
            product.AddImage("gt");
            //act
            product.RemoveImage(0);
            //assert
            product.Images.Should().HaveCount(0);
        }
        [Fact]
        public void RemoveImage_Should_ThrowException_When_Image_IsNot_Exist()
        {
            //arrange
            var product = productBuilder.SetTitle("ttil").SetMoney(new Money(1000)).Build();
            //act
            var action = (() => {
                product.RemoveImage(0);
            });
            //assert
            action.Should().Throw<NullOrEmptyDomainDataException>().WithMessage("image is not found");

        }

    }
}
