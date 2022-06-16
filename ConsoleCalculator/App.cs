using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    //TODO Add feature to use result to calculation in new caclucation.
    public class App
    {
        Input input;
        bool isRunning;
        CalcLog log;
        public App()
        {
            input = new Input();
            log = new CalcLog();
        }
        internal void StartUp()
        {
            isRunning = true;
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
            Print.Calculate("", "Enter a number and an operator, Examples: \"22+\", \"-2*\", \"3,5-\", \"9/\"");
            try
            {
                Calculation calc = new Calculation();
                while (!input.InputCalculationFirstNumAndOperator(calc)) ;
                Console.Clear();
                Print.Calculate($"{calc.Num1} {calc.InputOperator}", "Enter a second number and press ENTER, Examples: \"22\", \"-2\", \"3,5\"");
                while (!input.InputCalculationSecondNum(calc)) ;
                calc.Result = calculator.Calculate(calc.Num1, calc.Num2, calc.InputOperator);
                log.Add(calc);
                Console.Clear();
                Print.Calculate(calc.ToString(), "Enter a new operator to calculate with result, or press ENTER to get back!");
                while (ReCalculate()) ;
            }
            catch(Exception e)
            {
                Console.Clear();
                Print.Error(e.Message);
                Calculate();
            }  
        }
        public bool ReCalculate()
        {
            bool errorBool = false;
            Calculator calculator = new Calculator();
            Calculation prevCalc = log.GetCalculation(log.Count-1);
            Calculation calc = new Calculation()
            {
                Num1 = prevCalc.Result
            };
            do
            {
                try
                {
                    string op = input.InputOperator();
                    if (string.IsNullOrEmpty(op))
                    {
                        return false;
                    }
                    calc.InputOperator = op;
                    errorBool = false;
                }
                catch (Exception e)
                {
                    Print.Error(e.Message);
                    errorBool = true;
                }
            } while (errorBool);
            Console.Clear();
            Print.Calculate($"{calc.Num1} {calc.InputOperator}", "Enter a second number and press ENTER, Examples: \"22\", \"-2\", \"3,5\"");
            while (!input.InputCalculationSecondNum(calc)) ;
            calc.Result = calculator.Calculate(calc.Num1, calc.Num2, calc.InputOperator);
            log.Add(calc);
            Console.Clear();
            Print.Calculate(calc.ToString(), "Enter a new operator to calculate with result, or press ENTER to get back!");
            return true;
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
