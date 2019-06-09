using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestFramework.DataProvider;

namespace TestFramework.Pages
{
    public class SettlementMonitorPage : _BasePage
    {
        public SettlementMonitorPage()
        {
            _driver.Url =
                "http://backoffice.kube.private/monitors/settlement?betSettlementFilterFrom=1559854800000&betSettlementFilterTo=1559941199999";
        }

        public SettlementMonitorPage Authorize()
        {
            _driver.FindElement(By.XPath("//input[@placeholder=\'Username\']")).SendKeys("admin@betlab");
            _driver.FindElement(By.XPath("//input[@type=\'password\']")).SendKeys("abc");
            _driver.FindElement(By.XPath("//button[@type=\'submit\']")).Click();
            return this;
        }

        public SettlementMonitorPage SelectCalendar()
        {
            _driver.FindElement(By.ClassName("mx-calendar-icon")).Click();
            return this;
        }

        public SettlementMonitorPage ClickOnCalendarDate()
        {
            _driver.FindElement(By.XPath("//td[@title='01.06.19' and@class='cell cur-month']")).Click();
            _driver.FindElement(By.XPath("//button[@class='link transparent refresh']")).Click();
            return this;
        }

        public SettlementMonitorPage ClickOnEvent()
        {
            _driver.FindElement(By.XPath("//span[@class='material-icons']")).Click();
            return this;
        }

        public SettlementMonitorPage ClickOnEventInRightPanel()
        {
            _driver.FindElement(By.XPath("//section[@class='settlement-event-list pinned']//div[@class='alert-item'][1]")).Click();
            return this;
        }

        public SettlementMonitorPage ClickOnEventInEventTree()
        {
            _driver.FindElement(By.XPath("//label[@class='title' and normalize-space(text())='Футбол']")).Click();
            _driver.FindElement(By.XPath("//label[@class='title' and normalize-space(text())='Австралия']")).Click();
            _driver.FindElement(
                    By.XPath("//label[@class='title' and text()[contains(.,'Виктория. Национальная Премьер-лига')]]"))
                .Click();
            _driver.FindElement(By.XPath("//span[@class='material-icons']")).Click();
            return this;
        }

        public SettlementMonitorPage SelectEtapSobitiya()
        {
            _driver.FindElement(By.XPath("//div[@class='bo-multiselect settlement-multiselect'][3]//*[@class = 'multiselect__select']")).Click();
            _driver.FindElement(By.XPath("//*[text()='Finished']")).Click();
            return this;
        }

        public EventProvider SelectEvent()
        {
            return new EventProvider 
            {

                eventTime = _driver
                    .FindElement(By.XPath(
                        "//section[@class='settlement-event-list pinned']//div[@class='event-time']")).Text,
                eventDate = _driver
                    .FindElement(By.XPath(
                        "//section[@class='settlement-event-list pinned']//div[@class='event-date']")).Text,
                eventName = _driver
                    .FindElement(By.XPath(
                        "//section[@class='settlement-event-list pinned']//div[@class='event-title has-tooltip']"))
                    .Text,
                eventDescription = _driver
                    .FindElement(By.XPath(
                        "//section[@class='settlement-event-list pinned']//div[@class='event-description has-tooltip']"))
                    .Text,
                eventAlert = _driver
                    .FindElement(By.XPath(
                        "//section[@class='settlement-event-list pinned']//div[@class='alerts-block']//i['warning']"))
                    .Text,
                eventStage = _driver
                    .FindElement(By.XPath(
                        "//section[@class='settlement-event-list pinned']//div[@class='event-stage']//div[@class='column score']//span[@class]"))
                    .Text,
                eventScore = _driver
                    .FindElement(By.XPath(
                        "//section[@class='settlement-event-list pinned']//div[@class='scoreBoard']//div[@class='column score']//span[@class]"))
                    .Text,
                eventSettlementState = _driver
                    .FindElement(By.XPath(
                        "//section[@class='settlement-event-list pinned']//section[@class='event-settlement-state']/span[2]"))
                    .Text
            };
        }

        public SettlementMonitorPage InputEventName(string eventName)
        {
            _driver.FindElement(By.XPath("//input[@placeholder ='Найти событие']")).SendKeys(eventName);
            return this;
        }


        public SettlementMonitorPage ClickOnBetInfo()
        {
            _driver.FindElement(By.XPath("//section[@class='event-bet-table-wrapper']//div/table[@class='mn-table bet-table']//tr[1]//button[@class='transparent icon']")).Click();
            return this;
        }

        public BetInfoProvider GetBetinfo()

        {
            return new BetInfoProvider
            {
                eventTime = _driver.FindElement(By.XPath("//table[@class='mn-table']/tbody//tr[1]//td[1]")).Text,
                betStatus = _driver.FindElement(By.XPath("//table[@class='mn-table']/tbody//tr[1]//td[2]")).Text,
                betResult = _driver.FindElement(By.XPath("//table[@class='mn-table']/tbody//tr[1]//td[3]")).Text,
                resultSource = _driver.FindElement(By.XPath("//table[@class='mn-table']/tbody//tr[1]//td[4]")).Text,
                eventName = _driver.FindElement(By.XPath("//table[@class='mn-table']/tbody//tr[1]//td[5]")).Text,
                marketName = _driver.FindElement(By.XPath("//table[@class='mn-table']/tbody//tr[1]//td[6]")).Text,
                comment = _driver.FindElement(By.XPath("//table[@class='mn-table']/tbody//tr[1]//td[7]")).Text
            };
        }
    }
}
