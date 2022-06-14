using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    public class Calculator 
    {
        public double Calculate(double num1, double num2, string inputOperator)
        {
            switch (inputOperator)
            {
                case "+":
                    return Addition(num1, num2);
                case "-":
                    return Subtraction(num1, num2);
                case "*":
                    return Multiplication(num1, num2);
                case "/":
                    return Division(num1, num2);
                default:
                    throw new Exception($"The operator \"{inputOperator}\" is not valid!\n");
            }
        }
        public double Addition(double num1, double num2)
        {
            return num1 + num2;
        }

        public double Subtraction(double num1, double num2)
        {
            return Math.Round(num1 - num2, 8);
        }

        public double Division(double num1, double num2)
        {
            return Math.Round(num1 / num2, 8);
        }

        public double Multiplication(double num1, double num2)
        {
            return Math.Round(num1 * num2, 8);
        }
    }
}
