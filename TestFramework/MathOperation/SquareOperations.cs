using System;
using System.Collections.Generic;
using System.Text;

namespace TestFramework.MathOperation
{
    public class SquareOperations
    {
        private double _temp;
        public void PowCalculate(int r)
        {
            _temp = r*r;
        }
        public double SquareCalculate ()
        {
            return 3.14 * _temp;
        }
    }
}
