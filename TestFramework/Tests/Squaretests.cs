using NUnit.Framework;
using System;
using System.Collections.Generic;
using TestFramework.MathOperation;

namespace TestFramework.Tests
{
    public class SquareTests
    {
        private SquareOperations _squareOperatioperations;

        [SetUp]
        public void BeforeTest()
        {
            _squareOperatioperations = new SquareOperations();

        }

        [Test]
        public void RoundSquare()
        {
            _squareOperatioperations.PowCalculate(9);
            var result = _squareOperatioperations.SquareCalculate();


            Assert.IsTrue(result > 0);
        }
    }
}
