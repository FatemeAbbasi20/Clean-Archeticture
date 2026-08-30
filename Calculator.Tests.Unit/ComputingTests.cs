using Calculator.Tests.Unit.ClassFixture;
using FluentAssertions;

namespace Calculator.Tests.Unit
{
    public class ComputingTests:IClassFixture<ComputingClassFixture>
     {
        Computing computing;
        public ComputingTests(ComputingClassFixture fixture)
        {
            computing = fixture.computing;
        }
        [Fact]
        public void OddOrEven_should_return_odd_when_thevalue_is_Odd()
        {
           
            var actual=computing.OddOrEven(1);
            Assert.Equal("Odd",actual);
        }
        [Theory]
        [InlineData(2)]
        public void OddOrEven_should_return_even_when_thevalue_is_even(int value)
        {
            var actual = computing.OddOrEven(value);
            Assert.Equal("Even", actual);
        }
        [Fact]
        public void CalculateAge_Should_Return_Zero_When_BirthDate_Is_Zero()
        {
            //act
            var result = computing.CalculateAge(-1, 1379);
            //assert
            result.Should().Be(0);

        }
        [Fact]
        public void CalculateAge_Should_Return_ArgumentException_When_BirthDate_Or_CurrentAge_Is_Zero()
        {
            //act
            var result = (() => {
                computing.CalculateAge(1356, 0);
            });
                //assert
                result.Should().Throw<ArgumentException>();
           

        }
        [Fact]
        public void CalculateAge_Should_Calculate_Age_When_BirthDate_And_CurrentYear_Are_Valid_Data()
        {
            //act
            var result = computing.CalculateAge(1379, 1405);
            //assert
            result.Should().Be(26);

        }
        [Fact]
        public void IsPrime_Should_Return_False_When_Value_Is_Less_Than_Two()
        {
            var result=computing.IsPrime(1);
            result.Should().Be(false);
        }
        [Fact]
        public void IsPrime_Should_Return_False_When_Value_divide_To_divistor_Left_Zero()
        {
            var result = computing.IsPrime(9);
            result.Should().Be(false);

        }
        [Fact]
        public void IsPrime_Should_Return_True()
        {
            var result = computing.IsPrime(7);
            result.Should().Be(true);

        }
        

        
    }
}