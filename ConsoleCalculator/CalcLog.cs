using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{

    public class CalcLog : ICollection
    {
        List<Calculation> log;
        public CalcLog()
        {
            log = new List<Calculation>();
        }

        public int Count => log.Count;

        public bool IsSynchronized => false;

        public object SyncRoot => throw new NotImplementedException();

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
        public bool Add(Calculation calculation)
        {
            try
            {
                log.Add(calculation);
                return true;
            }catch(Exception)
            {
                return false;
            }
        }
        public void AddMockCalculations()
        {
            log.Add(new Calculation() { Num1 = 2, Num2 = 2,InputOperator = "+", Result = 4 });
            log.Add(new Calculation() { Num1 = 8, InputOperator = "-", Num2 = 4, Result = 4 });
            log.Add(new Calculation() { Num1 = 2, InputOperator = "*", Num2 = 2, Result = 4 });
            log.Add(new Calculation() { Num1 = 8, InputOperator = "/", Num2 = 2, Result = 4 });
            log.Add(new Calculation() { Num1 = 20, InputOperator = "+", Num2 = 5, Result = 25 });
        }
        public void Clear()
        {
            log.Clear();
        }
        public string GetLog()
        {
            string output = "";
            for (int i = 0; i < log.Count; i++)
            {
                output += $"\t{i + 1}. {log[i].ToString()}\n";
            }
            return output;
        }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}
