using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace TestFramework.Pages
{
    public class RegistrationPage : BasePage
    {
        public RegistrationPage()
        {
            Driver.Url = "http://air-pm-skeleton-bl.hp.consul/en/regmail";
        }
        public RegistrationPage InsertEmail(string email)
        {
            Driver.FindElement(By.Id("email")).SendKeys(email);
            return this;
        }
        public RegistrationPage SelectBirthDay(string year, string month, string day)
        {
            SelectBirthday(day);
            SelectBirthMonth(month);
            SelectBirthYear(year);
            return this;
        }
        public RegistrationPage SelectCurrency(string currency)
        {
            IWebElement selectcurrency = Driver.FindElement(By.Id("currencyId"));
            SelectElement select = new SelectElement(selectcurrency);
            select.SelectByValue(currency);
            return this;
        }
        public RegistrationPage InsertPassword(string password)
        {
            Driver.FindElement(By.Id("password")).SendKeys(password);
            return this;
        }
        public void SubmitRegistration()
        {
            Driver.FindElement(By.CssSelector(".form-wrap__footer>button")).Click();
        }
        private void SelectBirthday(string day)
        {
            IWebElement selectday = Driver.FindElement(By.XPath("//select[@ref='day']"));
            SelectElement selectByDay  = new SelectElement(selectday);
            selectByDay.SelectByValue(day.ToString());
        }

        private void SelectBirthMonth(string month)
        {
            IWebElement selectmonth = Driver.FindElement(By.XPath("//select[@ref='month']"));
            SelectElement selectByMonth = new SelectElement(selectmonth);
            selectByMonth.SelectByValue(month.ToString());
        }

        private void SelectBirthYear(string year)
        {
            IWebElement selectyear = Driver.FindElement(By.XPath("//select[@ref='year']"));
            SelectElement selectByYear = new SelectElement(selectyear);
            selectByYear.SelectByValue(year.ToString());
        }

    }
}