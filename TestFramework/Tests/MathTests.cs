using NUnit.Framework;
using TestFramework.MathOperation;

namespace TestFramework
{
    [TestFixture]
    public class MathTests
    {
        private EvenOddOperations _evenOddOperations;

        [SetUp]
        public void BeforeTest()
        {
            _evenOddOperations = new EvenOddOperations();
        }

        [TestCase(5, TestName = "Positive 5 odd test")]
        [TestCase(7, TestName = "Positive 7 odd test")]
        [TestCase(8, TestName = "Negative 8 odd test")]
        public void OddTest(int number) 
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(6, number, "Expected number 6");
                Assert.IsTrue(_evenOddOperations.IsNumberOdd(number), $"The number {number} is not even");
            });          
        }

        [TestCase(10, TestName = "Positive 10 even test")]
        [TestCase(20, TestName = "Positive 20 even test")]
        [TestCase(19, TestName = "Negative 19 even test")]
        public void EvenTest(int number)
        {
            Assert.IsTrue(_evenOddOperations.IsNumberEven(number), $"The number {number} is not odd");
        }

    }

}