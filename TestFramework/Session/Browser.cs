using System;
using System.Dynamic;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestFramework.Session
{
    public class Browser
    {
        public readonly string _browser  = "Chrome";

        public Browser()
        {
            _browser = "Chrome";
        }

        public IWebDriver Build()
        {
            IWebDriver driver;
            if (_browser == "Chrome")
            {
                var options = new ChromeOptions();
                options.AddArgument("start-maximized");// fullscreen
                driver = new ChromeDriver(Directory.GetCurrentDirectory(),options);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            else
            {
                return null;
            }

            return driver;
        }
    }
}