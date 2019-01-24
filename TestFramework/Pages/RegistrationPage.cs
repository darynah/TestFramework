using System;
using OpenQA.Selenium;

namespace TestFramework.Pages
{
    public class RegistrationPage : _BasePage
    {
        public void InsertEmail(string email)
        {
            _driver.FindElement(By.Id("email")).SendKeys(email);
        }
        public void SelectBirthDay(int year, int month, int day)
        {
            throw new NotImplementedException();
        }
        public void SelectCurrency(string currency)
        {
            throw new NotImplementedException();
        }
        public void InsertPassword(string password)
        {
            throw new NotImplementedException();
        }
        public void SubmitRegistration()
        {
            throw new NotImplementedException();
        }
    }
}