using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace TestFramework.Pages
{
    public class SuccsessRegistrationPage : _BasePage
    {
        private readonly By _headerUserName;

        public SuccsessRegistrationPage()
        {
            _headerUserName = By.ClassName("header-user_link");
        }

        public string GetRegistredEmail()
        {
            var element = _driver.FindElement(By.ClassName("short-registration-success__email"));
            return element.Text; ;
        }
    }
}