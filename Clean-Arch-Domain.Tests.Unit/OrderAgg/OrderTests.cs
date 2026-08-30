using Clean_Arch.Domain.Orders;
using Clean_Arch.Domain.OrdersAgg.Events;
using Clean_Arch.Domain.OrdersAgg.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using Clean_Arch.Domain.Shared;
using Clean_Arch.Domain.OrdersAgg.Exceptions;
using NSubstitute.ExceptionExtensions;

namespace Clean_Arch_Domain.Tests.Unit.OrderAgg
{
    public class OrderTests
    {
        Order order;
        public OrderTests()
        {
            order= new Order(1);
        }
        [Fact]
        public void Should_Create_Order()
        {
            //arrenge
            //act
            //asserts
            order.UserId.Should().Be(1);
        }
        [Fact]
        public void Finally_Should_FinallyOrder_And_Add_DomainEvent()
        {
            //arrenge
            //act
            order.Finally();
            //asserts
            //order.DomainEvents.Should().ContainEquivalentOf(new OrderFinalized(1, 0));
            order.DomainEvents.Should().HaveCount(1);
        }
        [Fact]
        public void AddItems_Should_Throw_ProductNotFoundException_When_Product_Is_Not_Exist()
        {
            //arrenge
            var orderService = Substitute.For<IOrderDomainService>();
            orderService.IsProductNotExisted(1).Returns(true);
            //act
            var result = () => { order.AddItem(1, 2, Money.FromRial(200), orderService); };
            //asserts
            result.Should().ThrowExactly<ProductNotFoundException>();
        }
        [Fact]
        public void AddItemss_Should_not_AddProduct_ToOrder_When_Product_Is_Exist()
        {
            //arrenge
            var orderService = Substitute.For<IOrderDomainService>();
            orderService.IsProductNotExisted(1).Returns(false);
            order.AddItem(1, 2, Money.FromRial(200), orderService);
            //act
            order.AddItem(1, 3, Money.FromRial(200), orderService);
            //asserts
            order.TotlaCount.Should().Be(2);
        }
        [Fact]
        public void AddItems_Should_AddItems_When_Data_Is_Valid()
        {  //arrenge
            var orderService = Substitute.For<IOrderDomainService>();
            orderService.IsProductNotExisted(1).Returns(false);
            //act
            order.AddItem(1, 5, Money.FromRial(200), orderService);
            //asserts
            order.TotlaCount.Should().Be(5);
            
        }
        [Fact]
        public void RemoveItem_Should_Throw_ProductNotFoundException_When_Product_Is_Not_Exist()
        { //arrenge
            var orderService = Substitute.For<IOrderDomainService>();
            orderService.IsProductNotExisted(1).Returns(false);
            order.AddItem(1, 2, Money.FromRial(200), orderService);
            //act
            var result = () => { order.RemoveItem(2); };
            //asserts
            result.Throws<ProductNotFoundException>();
        }
        [Fact]
        public void RemoveItem_Should_RemoveItem()
        {
            //arrenge
            var orderService = Substitute.For<IOrderDomainService>();
            orderService.IsProductNotExisted(1).Returns(false);
            order.AddItem(1, 3, Money.FromRial(200), orderService);
            //act
            order.RemoveItem(1);
            //asserts
            //order.Items.Should().HaveCount(0);
            order.TotlaCount.Should().Be(0);
        }

    }
}
