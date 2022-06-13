using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    public class Input
    {
        public string InputMenu(int max, string testval = "")
        {
            int num;
            string input;
            if(testval != "")
                input = testval;
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
            string input;
            if (testVal != "")
                input = testVal;
            else
                input = Console.ReadLine();
            return Double.TryParse(input, out num) ? num :
                throw new Exception($"The input {input} is not a number!\n" +
                $"\n\tExample: \"2,5\", \"86\", \"95,7\", \"-63\"\n");
        }

        public string InputOperator(string testVal = "")
        {
            string input;
            string operators = "+-*/";
            if (testVal != "")
                input = testVal;
            else
                input = Console.ReadKey().KeyChar.ToString();
            if (input.Length == 1 && operators.Contains(input))
                return input;
            else
                throw new Exception($"The input {input} is not a valid operator!\n" +
                    $"\tExample: \"+\", \"-\", \"*\", \"/\"\n");
        }
    }
}
