using System;
using Xunit;


namespace ConsoleCalculator.Test
{
    public class InputTest
    {
        Input sut;
        public InputTest()
        {
            sut = new Input();
        }
        [Fact]
        public void InputMenuTest()
        {
            //Arrange
            //Act
            var actual = sut.InputMenu(5, "2");
            var expected = "2";
            //Assert
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(5, "8")]
        [InlineData(5, "0")]
        [InlineData(5, "H")]
        public void InputMenuTest_Throw_Exception(int max, string input)
        {
            //Assert
            Assert.Throws<Exception>(() => sut.InputMenu(max, input));
        }
        [Theory]
        [InlineData(5, "5")]
        [InlineData(-35, "-35")]
        [InlineData(5.20, "5,20")]
        [InlineData(92.38, "92,38")]
        public void Input_Double(double expected, string input)
        {
            var actual = sut.InputDouble(input);
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("5,,6")]
        [InlineData("92.65")]
        [InlineData("HEJ")]
        public void Input_Double_Throw_Exception(string input)
        {
            Assert.Throws<Exception>(() => sut.InputDouble(input));
        }

        [Theory]
        [InlineData("+")]
        [InlineData("-")]
        [InlineData("*")]
        [InlineData("/")]
        public void Input_Operator(string input)
        {
            var actual = sut.InputOperator(input);
            Assert.Equal(input, actual);
        }
        [Theory]
        [InlineData("u")]
        [InlineData("4")]
        [InlineData("@")]
        [InlineData("hui")]
        [InlineData("¨")]
        public void Input_Operator_Throws_Exception(string input)
        {
            Assert.Throws<Exception>(() => sut.InputOperator(input));

        }
        [Theory]
        [InlineData("22+")]
        [InlineData("-85-")]
        [InlineData("5,38*")]
        [InlineData("9256,56/")]
        public void InputCalculation_Returns_True(string testVal)
        {
            //Arrange
            Calculation calc = new Calculation();
            //Act
            var actual = sut.InputCalculationFirstNumAndOperator(calc, testVal);
            //Assert
            Assert.True(actual);
        }

        [Theory]
        [InlineData("22&")]
        [InlineData("-Ö85-")]
        [InlineData("5.38*")]
        [InlineData(",9256,56/")]
        public void InputCalculation_Returns_False(string testVal)
        {
            //Arrange
            Calculation calc = new Calculation();
            //Act
            var actual = sut.InputCalculationFirstNumAndOperator(calc, testVal);
            //Assert
            Assert.False(actual);
        }
    }
}
