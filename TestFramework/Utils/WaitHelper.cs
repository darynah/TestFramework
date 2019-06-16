using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestFramework.Utils
{
    public class WaitHelper
    {
        private IWebDriver _driver;
        public WaitHelper(IWebDriver driver)
        {
            _driver = driver;
        }

        public void UntilPageIsReady(int sleepSeconds = 0, string elementToBeReady = null, int baseTimeOut = 10)
        {
            if (sleepSeconds > 0)
                Thread.Sleep(TimeSpan.FromSeconds(sleepSeconds));

            IWait<IWebDriver> wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(baseTimeOut));
            //wait.Until(driver1 => (bool)((IJavaScriptExecutor)Driver).ExecuteScript("return jQuery.active == 0"));
            wait.Until(driver1 => ((IJavaScriptExecutor)_driver).ExecuteScript("return document.readyState").Equals("complete"));

            if (elementToBeReady != null)
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(elementToBeReady)));
        }
    }
}