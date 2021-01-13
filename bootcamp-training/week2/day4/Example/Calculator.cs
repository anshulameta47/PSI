using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class Calculator
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public int Add()
        {
            return FirstNumber + SecondNumber;
        }
        static void Main(string[] args)
        {
        }
        public int Divide()
        {
            if (Denominator != 0)
                return Numerator / Denominator;
            throw new DivideByZeroException("Denominator should not be zero");
        }
    }
}
