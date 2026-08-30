using Clean_Arch.Domain.Shared;
using Clean_Arch.Domain.Shared.Exceptions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch_Domain.Tests.Unit.Shared
{
    public  class MoneyTests
    {
        [Fact]
        public void Constractor_Should_Set_Values_When_RialValue_Is_BiggerThan_Zero()
        {
            var money = new Money(1000);
            money.RialValue.Should().Be(1000);
        }
        [Fact]
        public void Should_Throw_InvalidDataDomainException_When_rialValue_Is_Less_Tahn_Zero()
        {
            var money = (() => { new Money(-1); });
            money.Should().ThrowExactly<InvalidDataDomainException>();
        }
        [Fact]
        public void FromRial_should_create_NewMoney()
        {
            var money = Money.FromRial(2000);
            money.RialValue.Should().Be(2000);
        }
        [Fact]
        public void FromTomman_Should_Create_NewMoney_With_Tomman_Value()
        {
            var tomanValue = 4000;
            var money = Money.FromToman(tomanValue);
            money.RialValue.Should().Be(tomanValue*10);

        }
        [Fact]
        public void Plus_Operator_Should_Sum_Values_And_Return_NewMoney()
        {
            //arrenge
            var money1 = Money.FromRial(40);
            var money2 = Money.FromRial(50);
            //act
            var result= money1 + money2;
            //asserts
            result.RialValue.Should().Be(90);
        }
        [Fact]
        public void Subtract_Operator_Should_Subtract_Values_And_Return_NewMoney()
        {
            //arrenge
            var money1 = Money.FromRial(600);
            var money2 = Money.FromRial(500);
            //act
            var result = money1 - money2;
            //asserts
            result.RialValue.Should().Be(100);
        }
        [Fact]
        public void ToString_Should_return_Money_In_String_format()
        {
            //arrenge
            var money = Money.FromRial(800000);
            //act
            var result = money.ToString();
            //asserts
            result.Should().Be("800,000");

        }

    }
}
