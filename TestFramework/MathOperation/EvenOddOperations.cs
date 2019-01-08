using System;
using System.Collections.Generic;
using System.Text;

namespace TestFramework.MathOperation
{
    class EvenOddOperations
    {
        public bool IsNumberOdd(int number)
        {
            return number % 2 != 0;
        }
        public bool IsNumberEven(int number)
        {
            return number % 2 == 0;
        }
    }
}
