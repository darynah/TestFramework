using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestFramework.Session
{
    public static class DriverManager
    {
        public static readonly ThreadLocal<IWebDriver> _Driver = new ThreadLocal<IWebDriver>();

        public static void SetDriver(IWebDriver driver)
        {
            _Driver.Value = driver;
        }

        public static IWebDriver GetDriver()
        {
            return _Driver.Value;
        }

        public static IJavaScriptExecutor GetJsExecutor()
        {
            return (IJavaScriptExecutor) _Driver.Value;
        }
    }
}