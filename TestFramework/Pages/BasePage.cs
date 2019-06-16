using OpenQA.Selenium;
using TestFramework.Session;
using TestFramework.Utils;

namespace TestFramework.Pages
{
    public class BasePage
    {
        public IWebDriver Driver = DriverManager.GetDriver();
        public IWebDriver DriverTimeout = DriverManager.GetDriver();
        public WaitHelper Wait => new WaitHelper(Driver);

        public IWebElement MoveToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            return element;
        }
    }
}