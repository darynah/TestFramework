using OpenQA.Selenium;

namespace TestFramework.Pages
{
    public class AuthorizationMonitor : BasePage
    {
        private string SignInButtonXpath => "//div[@class='app']//button[contains(text(),'Sign in')]";
        private IWebElement GetUsername => Driver.FindElement(By.XPath("//input[@placeholder=\'Username\']"));
        private IWebElement GetPassword => Driver.FindElement(By.XPath("//input[@type=\'password\']"));
        private IWebElement GetSignInButton => Driver.FindElement(By.XPath(SignInButtonXpath));
        public AuthorizationMonitor GoToPage()
        {
            Driver.Url = "http://backoffice.kube.private/login";
            Wait.UntilPageIsReady(3, SignInButtonXpath);
            return this;
        }

        public AuthorizationMonitor Authorize()
        {
            Wait.UntilPageIsReady(3, SignInButtonXpath);
            GetUsername.SendKeys("admin@betlab");
            Wait.UntilPageIsReady(3, SignInButtonXpath);
            GetPassword.SendKeys("abc");
            Wait.UntilPageIsReady(3, SignInButtonXpath);
            GetSignInButton.Click();
            Wait.UntilPageIsReady(3);
            return this;
        }
    }
}