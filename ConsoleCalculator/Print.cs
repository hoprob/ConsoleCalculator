using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    public static class Print
    {
        public static void MainMenu()
        {
            Console.WriteLine("\t** Main Menu **\n\n" +
                              "\t1.Calculate\n" +
                              "\t2.Log\n" +
                              "\t3.Quit\n" +
                              "\n\tInsert number to navigate");
        }
        public static void Calculate(string calculation, double result)
        {
            Console.Write("\t** Calculate **\n\n");
            Console.Write($"\t{calculation} = {result}\n\t");
        }
        public static void Calculate(string calculation, string instructions)
        {
            Console.Write("\t** Calculate **\n\n");
            Console.Write($"\t{calculation}\n");
            Console.SetCursorPosition(8, 8);
            Console.Write(instructions);
        }
        public static void Log(CalcLog log)
        {
            Console.Write($"\t** Calculator Log **\n\n{log.GetLog()}");
        }
        public static void FirstNumber()
        {
            Console.Write("\tEnter first number and press ENTER: ");
        }
        public static void SecondNumber()
        {
            Console.Write("\tEnter second number and press ENTER: ");
        }
        public static void Result(double result)
        {
            Console.Write($"Result is: {result}");
        }
        public static void Error(string exception)
        {
            Console.SetCursorPosition(5, 15);
            Console.Write($"\n\tERROR! {exception}                                                                         \n" +
                $"                                                                                                           ");
            Console.SetCursorPosition(0, 0);
        }

        public static void GetOperator()
        {
            Console.Write("\tEnter an operator: ");
        }
        public static void GetBack()
        {
            Console.Write("\n\n\tPress ENTER to get back!");
        }
        public static void QuitQuestion()
        {
            Console.Clear();
            Console.Write("\n\tDo you really want to quit? \n\n\t\t[Y/N]");
        }
    }
}
