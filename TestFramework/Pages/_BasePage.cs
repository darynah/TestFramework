using OpenQA.Selenium;
using TestFramework.Session;

namespace TestFramework.Pages
{
    public class _BasePage
    {
        public IWebDriver _driver = DriverManager.GetDriver();
        public IWebDriver _driverTimeout = DriverManager.GetDriver();

        public IWebElement MoveToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            return element;
        }
    }
}