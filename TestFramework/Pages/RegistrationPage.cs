﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace TestFramework.Pages
{
    public class RegistrationPage : _BasePage
    {
        public RegistrationPage()
        {
            _driver.Url = "http://air-pm-skeleton-bl.hp.consul/en/regmail";
        }
        public void InsertEmail(string email)
        {
            _driver.FindElement(By.Id("email")).SendKeys(email);
        }
        public void SelectBirthDay(string year, string month, string day)
        {
            SelectBirthday(day);
            SelectBirthMonth(month);
            SelectBirthYear(year);
        }
        public void SelectCurrency(string currency)
        {
            IWebElement selectcurrency = _driver.FindElement(By.Id("currencyId"));
            SelectElement select = new SelectElement(selectcurrency);
            select.SelectByValue(currency);
        }
        public void InsertPassword(string password)
        {
            _driver.FindElement(By.Id("password")).SendKeys(password);
        }
        public void SubmitRegistration()
        {
            _driver.FindElement(By.CssSelector(".form-wrap__footer>button")).Click();
        }
        private void SelectBirthday(string day)
        {
            IWebElement selectday = _driver.FindElement(By.XPath("//select[@ref='day']"));
            SelectElement selectByDay  = new SelectElement(selectday);
            selectByDay.SelectByValue(day.ToString());
        }

        private void SelectBirthMonth(string month)
        {
            IWebElement selectmonth = _driver.FindElement(By.XPath("//select[@ref='month']"));
            SelectElement selectByMonth = new SelectElement(selectmonth);
            selectByMonth.SelectByValue(month.ToString());
        }

        private void SelectBirthYear(string year)
        {
            IWebElement selectyear = _driver.FindElement(By.XPath("//select[@ref='year']"));
            SelectElement selectByYear = new SelectElement(selectyear);
            selectByYear.SelectByValue(year.ToString());
        }

        public string GetRegistredEmail()
        {
            var element = _driver.FindElement(By.ClassName("short-registration-success__email"));
            return element.Text; ;
        }
    }
}