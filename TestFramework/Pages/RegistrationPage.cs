using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


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
        private void SelectBirthday(int day)
        {
            var dayt = _driver.FindElement(By.XPath("//select[@ref='day']"));
            var selectelement =  new SelectElement(dayt);
            //selectelement.SelectByIndex();
        }
        private void SelectBirthMonth(int month)
        {
            throw new NotImplementedException();
        }
        private void SelectBirthYear(int year)
        {
            throw new NotImplementedException();
        }

    }
}