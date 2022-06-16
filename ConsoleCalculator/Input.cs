using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    public class Input
    {
        public string InputMenu(int max, string testVal = "")
        {
            int num;
            string input;
            if(testVal != "")
                input = testVal;
            else
                input = Console.ReadKey().KeyChar.ToString();
            if (Int32.TryParse(input, out num))
            {
                if(num <= max && num > 0)
                {
                    return num.ToString();
                }
                throw new Exception($"The input {num} is out of range!\n\tEnter a number between 1 and {max}!\n\n");
            }
            throw new Exception($"The input {num} is not a number!\n\tEnter a number between 1 and {max}!\n\n");
        }

        public double InputDouble(string testVal = "")
        {
            double num;
            string? input;     
            if (testVal != "")
                input = testVal;
            else
            {
                ClearInputCalculatorRow();
                Console.SetCursorPosition(9, 5);
                input = Console.ReadLine();
            }
            return Double.TryParse(input, out num) ? num :
                throw new Exception($"The input {input} is not a number!\n" +
                $"\n\tExample: \"2,5\", \"86\", \"95,7\", \"-63\"\n");
        }
        public bool InputCalculationFirstNumAndOperator(Calculation calc, string testVal = "")
        {
            string input;
            string calculation = "";
            string validNum = "0123456789,";
            string validOp = "+-*/";
            double num1;
            bool testBool = false;
            //Checks if there's a test value
            if(testVal != "")
            {
                calculation = testVal;
                testBool = true;
            }
            else
            {
                //Get first number and break when entering an operator
                ClearInputCalculatorRow();
                Console.SetCursorPosition(9, 5);
                do
                {
                    input = Console.ReadKey().KeyChar.ToString();
                    calculation += input;
                } while (validNum.Contains(input) || (calculation.Length == 1 && input == "-"));
            }
            //Gets the operator and removes it from string
            string op = calculation.Substring(calculation.Length - 1, 1);
            calculation = calculation.Remove(calculation.Length - 1);
            //Check that first number is parseable to double
            if (Double.TryParse(calculation, out num1))
                calc.Num1 = num1;
            else
            {
                if(!testBool)
                    Print.Error($"The input {calculation} is not a number!\n" +
                        $"\n\tExample: \"2,5\", \"86\", \"95,7\", \"-63\"\n");
                return false;
            }
            //Check that operator is valid
            if (validOp.Contains(op))
                calc.InputOperator = op;
            else
            {
                if(!testBool)
                    Print.Error($"The input {op} is not a valid operator!\n" +
                        $"\tExample: \"+\", \"-\", \"*\", \"/\"\n");
                return false;
            }
            return true;
        }
        public bool InputCalculationSecondNum(Calculation calc)
        {
            try
            {
                calc.Num2 = InputDouble();
                return true;
            }
            catch (Exception e)
            {
                Print.Error(e.Message);
                return false;
            }
        }
        public string InputOperator(string testVal = "")
        {
            string input;
            string operators = "+-*/";
            if (testVal != "")
                input = testVal;
            else
            {
                ClearInputCalculatorRow();
                Console.SetCursorPosition(9, 5);
                char inputChar = Console.ReadKey().KeyChar;
                if (inputChar == '\r')
                    return "";
                input = inputChar.ToString();
            }
            if (input.Length == 1 && operators.Contains(input))
                return input;
            else
                throw new Exception($"The input {input} is not a valid operator!\n" +
                    $"\tExample: \"+\", \"-\", \"*\", \"/\"\n");
        }
        public bool InputQuitQuestion()
        {
            while(true)
            {
                string input = Console.ReadKey().KeyChar.ToString();
                if (input == "N" || input == "n")
                    return false;
                else if (input == "Y" || input == "y")
                    return true;
                else
                {
                    Print.Error("You have to enter Y or N !!\n\t");
                }
            }
        }
        public void ClearInputCalculatorRow()
        {
            Console.SetCursorPosition(0, 5);
            Console.Write("                                                                                               ");
        }
    }
}
