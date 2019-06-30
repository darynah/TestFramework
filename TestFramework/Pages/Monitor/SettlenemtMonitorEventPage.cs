using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace TestFramework.Pages
{
    public class SettlenemtMonitorEventPage : BasePage
    {
        private IWebElement GetFilterByAmount(string parameter) => Driver.FindElement(
            By.XPath($"//input[@placeholder='{parameter}']"));
        private IWebElement CloseDashBoardbutton => Driver.FindElement(
            By.XPath("//section[@class='settlement-dashboard']//button[@class='icon transparent close-button']"));
        private IWebElement FirstPlayerId=> Driver.FindElement(
            By.XPath("//section[@class='event-bet-table-wrapper']/div/table[@class='mn-table bet-table']/tbody/tr[1]/td[3]"));

        private string ConfirmButtonInFilterXpath => "//button[@class='warning raised']";
        private string ArrowForLabelInFilter(string label) => $"//div[@class='event-bet-table-filter-form-control-wrapper' and label ='{label}']//div[@class ='multiselect__select']";
        private string OptionBlockXpath => "//div[@class='multiselect__content-wrapper' and not(contains(@style,'display: none;'))]";
        private string EventPageFilter => "//section[@class = 'event-bet-table-filter-wrapper']/button";
        private string DateFromInput => "//div[@class='custom-frame']//div[@class='custom-frame-from']//div[@class='mx-input-wrapper']//input[@type='text']";

        public SettlenemtMonitorEventPage GoToPage()
        {
            Driver.Url =
            "http://backoffice.kube.private/monitors/settlement/37157?betSettlementFilterText=Ливерпуль&betSettlementFilterFrom=1559336400000&betSettlementFilterTo=1559336400000";
            return this;
        }

        public SettlenemtMonitorEventPage CloseDashboard()
        {
            Wait.UntilPageIsReady(3);
            var closeDashBoardButton = Driver.FindElements(By.XPath("//section[@class='settlement-dashboard']//button[@class='icon transparent close-button']"));
            var elementExist = (closeDashBoardButton.Count >= 1) ? closeDashBoardButton.First() : null;
            if (elementExist != null)
            {
                CloseDashBoardbutton.Click();
            }
            return this;
        }

        public SettlenemtMonitorEventPage ClickOnFilterButton()
        {
            Wait.UntilPageIsReady(3,elementToBeReady: EventPageFilter);
            Driver.FindElement(By.XPath(EventPageFilter)).Click();
            return this;
        }

        public SettlenemtMonitorEventPage InsertDateFrom(string dateFrom)
        {
            Wait.UntilPageIsReady(elementToBeReady: DateFromInput);
            Driver.FindElement(By.XPath(DateFromInput)).SendKeys(dateFrom);
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
            Wait.UntilPageIsReady(3, elementToBeReady: arrow);
            Driver.FindElement(By.XPath(arrow)).Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(2000));
            var optionBlock = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(OptionBlockXpath)));
            optionBlock.FindElement(By.XPath($".//span[text()='{searchedElement}']/..")).Click();
            Driver.FindElement(By.XPath(ArrowForLabelInFilter(filterLabel))).Click();
            return this;
        }

        public SettlenemtMonitorEventPage PressConfirmButton()
        {
            Wait.UntilPageIsReady(3, elementToBeReady: ConfirmButtonInFilterXpath);
            Driver.FindElement(By.XPath(ConfirmButtonInFilterXpath)).Click();
            return this;
        }

        public SettlenemtMonitorEventPage PressFirtsPlayerIdInTable()
        {
            FirstPlayerId.Click();
            return this;
        }
    }
}