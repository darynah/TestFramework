using OpenQA.Selenium;

namespace TestFramework.Pages
{
    public class AuthorizationMonitor : BasePage
    {
        public AuthorizationMonitor GoToPage()
        {
            Driver.Url = "http://backoffice.kube.private/login";
            Wait.UntilPageIsReady(3, "//div[@class='app']//button[contains(text(),'Sign in')]");
            return this;
        }

        public AuthorizationMonitor Authorize()
        {
            Wait.UntilPageIsReady(3,"//div[@class='app']//button[contains(text(),'Sign in')]");
            Driver.FindElement(By.XPath("//input[@placeholder=\'Username\']")).SendKeys("admin@betlab");
            Wait.UntilPageIsReady(3, "//div[@class='app']//button[contains(text(),'Sign in')]");
            Driver.FindElement(By.XPath("//input[@type=\'password\']")).SendKeys("abc");
            Wait.UntilPageIsReady(3, "//div[@class='app']//button[contains(text(),'Sign in')]");
            Driver.FindElement(By.XPath("//button[@type=\'submit\']")).Click();
            Wait.UntilPageIsReady(3);
            return this;
        }
    }
}