﻿using Xunit;

namespace ConsoleCalculator.Test
{
    public class LogTest
    {
        CalcLog sut;
        public LogTest()
        {
            sut = new CalcLog();
        }

        [Fact]
        public void AddCalculation_Return_True()
        {
            //Arrange
            Calculation calc = new Calculation
            {
                calculation = "2 + 2",
                result = 4
            };
            //Act
            var actual = sut.Add(calc);
            //Assert
            Assert.True(actual);
        }
        [Fact]
        public void AddCalculation_Check_List_Is_Longer()
        {
            //Arrange
            Calculation calc = new Calculation
            {
                calculation = "2 + 2",
                result = 4
            };
            //Act
            var initialCount = sut.Count;
            sut.Add(calc);
            //Arrange
            Assert.Equal(initialCount + 1, sut.Count);
        }
        [Fact]
        public void Get_Log_As_String()
        {
            //Assert
            Calculation calc1 = new Calculation
            {
                calculation = "2 + 2",
                result = 4
            };
            Calculation calc2 = new Calculation
            {
                calculation = "6 * 6",
                result = 36
            };
            sut.Add(calc1);
            sut.Add(calc2);
            //Act
            var expected = "1. 2 + 2 = 4\n2. 6 * 6 = 36\n";
            var actual = sut.GetLog();
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
