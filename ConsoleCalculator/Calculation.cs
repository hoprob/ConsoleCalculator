using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    public class Calculation
    {
        public double Num1 { get; set; }
        public double Num2 { get; set; }
        public string InputOperator { get; set; }
        public double Result { get; set; }

        public Calculation()
        {
            this.InputOperator = "No Operator Assigned";
        }
        public Calculation(double num1, double num2, string inputOperator)
        {
            this.Num1 = num1;
            this.Num2 = num2;
            this.InputOperator = inputOperator;
        }
        public override string ToString()
        {
            return $"{Num1} {InputOperator} {Num2} = {Result}";
        }
    }
}
