using System;
using Xunit;

namespace ConsoleCalculator.Test
{
    public class CalculatorTest
    {
        private Calculator sut;

        public CalculatorTest()
        {
            sut = new Calculator();
        }

        [Fact]
        public void AdditionFact()
        {
            //Arrange
            //Act
            var actual = sut.Addition(5, 6);
            var expected = 11;
            //Assert
            Assert.True(actual == expected);
        }

        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(-3, 2, -1)]
        [InlineData(26.8, 92.4, 119.2)]
        [InlineData(-52.6, -0.9, -53.5)]
        [InlineData(2089, 6016.8, 8105.8)]
        public void AdditionTheory(double num1, double num2, double expected)
        {
            //Arrange

            //Act
            var actual = sut.Addition(num1, num2);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(5, 3, 2)]
        [InlineData(-6, -1, -5)]
        [InlineData(65.32, 49.3, 16.02)]
        [InlineData(-62.3, -5.9, -56.4)]
        [InlineData(6235.45, 5634.2, 601.25)]
        public void Subtraction(double num1, double num2, double expected)
        {
            //Act
            var actual = sut.Subtraction(num1, num2);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(9, 3, 3)]
        [InlineData(-6, -3, 2)]
        [InlineData(92.35, 51.3, 1.80019493)]
        [InlineData(-54.2, -10.2, 5.31372549)]
        [InlineData(8462.4, 4268.6, 1.98247669)]
        public void Division(double num1, double num2, double expected)
        {
            //Arrange
            //Act
            var actual = sut.Division(num1, num2);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(5, 8, 40)]
        [InlineData(-6, -9, 54)]
        [InlineData(53.32, 32.84, 1751.0288)]
        [InlineData(-56.8, -21.6, 1226.88)]
        [InlineData(3524.2, 1532.6, 5401188.92)]
        public void Multiplication(double num1, double num2, double expected)
        {
            //Arrange
            //Act
            var actual = sut.Multiplication(num1, num2);
            //Assert
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(2, 6, "+", 8)]
        [InlineData(-6, -3, "-", -3)]
        [InlineData(26.65, 62.89, "*", 1676.0185)]
        [InlineData(4961, 623, "/", 7.96308186)]
        public void CalculateTest(double num1, double num2, string inputOperator, double expected)
        {
            //Act
            var actual = sut.Calculate(num1, num2, inputOperator);
            //Assert
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(2, 6, "h")]
        [InlineData(-6, -3, "3")]
        [InlineData(26.65, 62.89, "-/")]
        [InlineData(4961, 623, "++")]
        public void CalculateTest_Not_Valid_Operator_Throws_Exception(double num1, double num2, string inputOperator)
        {
            Assert.Throws<Exception>(() => sut.Calculate(num1, num2, inputOperator));
        }
  
    }
}