using OpenQA.Selenium;

namespace TestFramework.Pages
{
    public class AuthorizationMonitor:_BasePage
    {
        public AuthorizationMonitor GoToPage()
        {
            _driver.Url = "http://backoffice.kube.private/login";
            return this;
        }
        public AuthorizationMonitor Authorize()
        {
            _driver.FindElement(By.XPath("//input[@placeholder=\'Username\']")).SendKeys("admin@betlab");
            _driver.FindElement(By.XPath("//input[@type=\'password\']")).SendKeys("abc");
            _driver.FindElement(By.XPath("//button[@type=\'submit\']")).Click();
            return this;
        }
    }
}