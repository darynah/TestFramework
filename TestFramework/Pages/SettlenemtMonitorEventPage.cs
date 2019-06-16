using OpenQA.Selenium;
using TestFramework.Tests;
using TestFramework.DataProvider;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestFramework.Pages
{
    public class SettlenemtMonitorEventPage:BasePage
    {
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

        public SettlenemtMonitorEventPage Authorize()
        {
            Driver.FindElement(By.XPath("//input[@placeholder=\'Username\']")).SendKeys("admin@betlab");
            Driver.FindElement(By.XPath("//input[@type=\'password\']")).SendKeys("abc");
            Driver.FindElement(By.XPath("//button[@type=\'submit\']")).Click();
            return this;
        }

        public SettlenemtMonitorEventPage ClickOnFilterButton()
        {
            var button = "//section[@class = 'event-bet-table-filter-wrapper']/button";
            Wait.UntilPageIsReady(elementToBeReady: button);
            Driver.FindElement(By.XPath(button)).Click();
            return this;
        }

        public SettlenemtMonitorEventPage InsertDate(string dateFrom)
        {
            Driver.FindElement(By.XPath("//div[@class='custom-frame']//div[@class='custom-frame-from']//div[@class='mx-input-wrapper']//input[@type='text']")).SendKeys(dateFrom);
            return this;
        }
        public SettlenemtMonitorEventPage InsertAmountFrom(string amountFrom)
        {
            Driver.FindElement(By.XPath("//input[@placeholder='От']")).SendKeys(amountFrom);
            return this;
        }
        public SettlenemtMonitorEventPage InsertAmountTo(string amountTo)
        {
            Driver.FindElement(By.XPath("//input[@placeholder='До']")).SendKeys(amountTo);
            return this;
        }

        public SettlenemtMonitorEventPage InsertSegment(string segment)
        {
            var arrow = "//div[@class='event-bet-table-filter-form-control-wrapper' and label ='Segment']//div[@class ='multiselect__select']";
            var optionBlockXpath = $"//div[@class='multiselect__content-wrapper' and not(contains(@style,'display: none;'))]";
            Driver.FindElement(By.XPath(arrow)).Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(2000));
            var optionBlock = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(optionBlockXpath)));
            optionBlock.FindElement(By.XPath($".//span[text()='{segment}']/..")).Click();
            return this;
        }

        public SettlenemtMonitorEventPage ClickOnEmptySpaceInFilter(string input)
        {
            var arrow = "//div[@class='event-bet-table-filter-form-control-wrapper' and label ='"+input+"']//div[@class ='multiselect__select']";
            var optionBlockXpath = "$//div[@class='multiselect__content-wrapper' and not(contains(@style,'display: none;'))]";
            Driver.FindElement(By.XPath(arrow)).Click();
            return this;
        }

        public SettlenemtMonitorEventPage InsertChannel(string channel)
        {
            var arrow = "//div[@class='event-bet-table-filter-form-control-wrapper' and label ='Channel']//div[@class ='multiselect__select']";
            var optionBlockXpath = $"//div[@class='multiselect__content-wrapper' and not(contains(@style,'display: none;'))]";
            Wait.UntilPageIsReady(3,elementToBeReady: arrow);
            Driver.FindElement(By.XPath(arrow)).Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(2000));
            var optionBlock = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(optionBlockXpath)));
            optionBlock.FindElement(By.XPath($".//span[text()='{channel}']/..")).Click();  
            return this;
        }
        public SettlenemtMonitorEventPage PressConfirmButtonn()
        {
            var button = "//button[@class='warning raised']";
            Wait.UntilPageIsReady(3, elementToBeReady: button);
            Driver.FindElement(By.XPath("//button[@class='warning raised']")).Click();
            return this;
        }

        public SettlenemtMonitorEventPage PressPlayerId()
        {
            Driver.FindElement(By.XPath("//section[@class='event-bet-table-wrapper']/div/table[@class='mn-table bet-table']/tbody/tr[1]/td[3]")).Click();
            return this;
        }
    }
}