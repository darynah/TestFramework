using OpenQA.Selenium;
using TestFramework.Session;

namespace TestFramework.Pages
{
    public class _BasePage
    {
        public IWebDriver _driver = DriverManager.GetDriver();
    }
}