using System;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace TestFramework.Utils
{
    public class WaitHelper
    {
        private IWebDriver _driver;

        public WaitHelper(IWebDriver driver)
        {
            _driver = driver;
        }

        public void UntilPageIsReady(int sleepSeconds = 0, string elementToBeReady = null, IWebElement element = null,
            int baseTimeOut = 10)
        {
            if (sleepSeconds > 0)
                Thread.Sleep(TimeSpan.FromSeconds(sleepSeconds));

            IWait<IWebDriver> wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(baseTimeOut));
            //wait.Until(driver1 => (bool)((IJavaScriptExecutor)Driver).ExecuteScript("return jQuery.active == 0"));
            wait.Until(driver1 =>
                ((IJavaScriptExecutor) _driver).ExecuteScript("return document.readyState").Equals("complete"));

            if (elementToBeReady != null)
                wait.Until(ExpectedConditions.ElementExists(By.XPath(elementToBeReady)));
        }

        public IWebElement UntilElementReady(IWebDriver driver, By by, int timeout = 5000)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));

            wait.Until(ExpectedConditions.ElementExists(by));

            wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));

            return driver.FindElement(by);
        }
    }
}