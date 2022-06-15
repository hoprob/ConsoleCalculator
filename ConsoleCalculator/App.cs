using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    //TODO Add feature to use result to calculation in new caclucation.
    //TODO Make input number "break"/"return" when user inputs operator.
    public class App
    {
        Input input;
        bool isRunning;
        CalcLog log;
        internal void StartUp()
        {
            input = new Input();
            isRunning = true;
            log = new CalcLog();
            log.AddMockCalculations(); //For Testing!!
            while(isRunning)
                MainMenu();
        }
        internal void MainMenu()
        {
            string userInput = "";
            try
            {
                Console.Clear();
                Print.MainMenu();
                userInput = input.InputMenu(3);
            }catch(Exception e)
            {
                Console.Clear();
                Print.Error(e.Message);
                MainMenu();
            }
            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    Calculate();
                    return;
                case "2":
                    Log();
                    return;
                case "3":
                    Print.QuitQuestion();
                    if (input.InputQuitQuestion())
                        isRunning = false;
                    return;
                default:
                    return;
            }
        }
        public void Calculate()
        {
            Calculator calculator = new Calculator();
            double num1;
            double num2;
            double result;
            string inputOperator = "";
            string calculation = "";
            
            Print.Calculate(calculation, "Enter a number and an operator, Examples: \"22+\", \"-2*\", \"3,5-\", \"9/\"");
            try
            {
                ////Num1
                //Print.FirstNumber();
                //num1 = input.InputDouble();
                //calculation += $"{num1} ";
                //Console.Clear();
                //Print.Calculate(calculation);
                ////Operator
                //Print.GetOperator();
                //inputOperator = input.InputOperator();
                //calculation += $"{inputOperator}";
                //Console.Clear();
                //Print.Calculate(calculation);
                ////Num2
                //Print.SecondNumber();
                //num2 = input.InputDouble();
                //calculation += $" {num2}";
                //Result
                Calculation calc = new Calculation();
                //input.InputCalculation();
                while (!input.InputCalculationFirstNumAndOperator(calc)) ;
                Console.Clear();
                Print.Calculate($"{calc.Num1} {calc.InputOperator}", "Enter a second number and press ENTER, Examples: \"22\", \"-2\", \"3,5\"");
                while (!input.InputCalculationSecondNum(calc)) ;
                calc.Result = calculator.Calculate(calc.Num1, calc.Num2, calc.InputOperator);
                //log.Add(new Calculation() { calculation = calculation, result = result });
                log.Add(calc);
                Console.Clear();
                //Print.Calculate(calculation, result);
                Print.Calculate(calc.ToString(), "");
                GetBack();
            }
            catch(Exception e)
            {
                Console.Clear();
                Print.Error(e.Message);
                Calculate();
            }  
        }

        public void Log()
        {
            Console.Clear();
            Print.Log(log);
            GetBack();
        }

        public void GetBack()
        {
            Print.GetBack();
            Console.ReadKey();
        }
    }
}
