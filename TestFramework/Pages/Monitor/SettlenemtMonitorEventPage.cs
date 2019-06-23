using OpenQA.Selenium;
using TestFramework.Tests;
using TestFramework.DataProvider;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestFramework.Pages
{
    public class SettlenemtMonitorEventPage:BasePage
    {
        private IWebElement GetFilterByAmount(string parameter)=>Driver.FindElement(By.XPath($"//input[@placeholder='{parameter}']"));

        private string ConfirmButtonInFilterXpath => "//button[@class='warning raised']";
        private string ArrowForLabelInFilter(string label) => $"//div[@class='event-bet-table-filter-form-control-wrapper' and label ='{label}']//div[@class ='multiselect__select']";

        public SettlenemtMonitorEventPage GoToPage()
        {
            Driver.Url =
            "http://backoffice.kube.private/monitors/settlement/37157?betSettlementFilterText=Ливерпуль&betSettlementFilterFrom=1559336400000&betSettlementFilterTo=1559336400000";
            return this;
        }

        public SettlenemtMonitorEventPage CloseDashboard()
        {
            Driver.FindElement(By.XPath("//section[@class='settlement-dashboard']//button[@class='icon transparent close-button']")).Click();
            return this;
        }

        public SettlenemtMonitorEventPage ClickOnFilterButton()
        {
            var button = "//section[@class = 'event-bet-table-filter-wrapper']/button";
            Wait.UntilPageIsReady(elementToBeReady: button);
            Driver.FindElement(By.XPath(button)).Click();
            return this;
        }

        public SettlenemtMonitorEventPage InsertDateFrom(string dateFrom)
        {
            Driver.FindElement(By.XPath("//div[@class='custom-frame']//div[@class='custom-frame-from']//div[@class='mx-input-wrapper']//input[@type='text']")).SendKeys(dateFrom);
            return this;
        }
        public SettlenemtMonitorEventPage InsertAmount(string parameter, string amount)
        {
            GetFilterByAmount(parameter).SendKeys(amount);
            return this;
        }

        public SettlenemtMonitorEventPage InsertTextIntoDropbown(string filterLabel, string searchedElement)
        {
            var arrow = ArrowForLabelInFilter(filterLabel);
            var optionBlockXpath = "//div[@class='multiselect__content-wrapper' and not(contains(@style,'display: none;'))]";
            Wait.UntilPageIsReady(3, elementToBeReady: arrow);
            Driver.FindElement(By.XPath(arrow)).Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(2000));
            var optionBlock = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(optionBlockXpath)));
            optionBlock.FindElement(By.XPath($".//span[text()='{searchedElement}']/..")).Click();
            return this;
        }

        public SettlenemtMonitorEventPage ClickOnEmptySpaceInFilter(string input)
        {
            Driver.FindElement(By.XPath(ArrowForLabelInFilter(input))).Click();
            return this;
        }

        public SettlenemtMonitorEventPage PressConfirmButton()
        {
            Wait.UntilPageIsReady(3, elementToBeReady: ConfirmButtonInFilterXpath);
            Driver.FindElement(By.XPath(ConfirmButtonInFilterXpath)).Click();
            return this;
        }

        public SettlenemtMonitorEventPage PressPlayerId()
        {
            Driver.FindElement(By.XPath("//section[@class='event-bet-table-wrapper']/div/table[@class='mn-table bet-table']/tbody/tr[1]/td[3]")).Click();
            return this;
        }
    }
}