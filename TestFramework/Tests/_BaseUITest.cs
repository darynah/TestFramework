using NUnit.Framework;
using TestFramework.Session;

namespace TestFramework.Tests
{
    public class _BaseUITest
    {
        [SetUp]
        public void InitTest()
        {
            var browser = new Browser();
            var driver = browser.Build();
            DriverManager.SetDriver(driver);
        }

        [TearDown]
        public void GeneralAfterTest()
        {
            DriverManager.GetDriver().Close();
        }
    }
}