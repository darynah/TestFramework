﻿using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestFramework.DataProvider;

namespace TestFramework.Pages
{
    public class SettlementMonitorPage : BasePage
    {
        private IWebElement GetSportCategoryButton(string sportName) =>  Driver.FindElement(By.XPath($"//label[@class='title' and normalize-space(text())='{sportName}']"));
        public SettlementMonitorPage GoPage()
        {
            Driver.Url =
                "http://backoffice.kube.private/monitors/settlement?betSettlementFilterFrom=1559854800000&betSettlementFilterTo=1559941199999";
            return this;
        }

        public SettlementMonitorPage CloseDashboard()
        {
            Driver.FindElement(By.XPath("//section[@class='settlement-dashboard']//button[@class='icon transparent close-button']")).Click();
            return this;
        }

        public SettlementMonitorPage Authorize()
        {
            Driver.FindElement(By.XPath("//input[@placeholder=\'Username\']")).SendKeys("admin@betlab");
            Driver.FindElement(By.XPath("//input[@type=\'password\']")).SendKeys("abc");
            Driver.FindElement(By.XPath("//button[@type=\'submit\']")).Click();
            return this;
        }

        public SettlementMonitorPage FilterByDateInCalendar(string date)
        {
            SelectCalendar();
            ClickOnCalendarDate(date);
            return this;
        }

        private void SelectCalendar()
        {
            Driver.FindElement(By.ClassName("mx-calendar-icon")).Click();
        }

        private void ClickOnCalendarDate(string date)
        {
            Driver.FindElement(By.XPath($"//td[@title='{date}' and@class='cell cur-month']")).Click();
            Driver.FindElement(By.XPath("//button[@class='link transparent refresh']")).Click();
        }

        public SettlementMonitorPage ClickOnEvent()
        {
            Driver.FindElement(By.XPath("//span[@class='material-icons']")).Click();
            return this;
        }

        public SettlementMonitorPage ClickOnEventInRightPanel()
        {
            Driver.FindElement(By.XPath("//section[@class='settlement-event-list pinned']//div[@class='alert-item'][1]")).Click();
            return this;
        }

        public SettlementMonitorPage ClickOnEventInEventTree()
        {
            var button = GetSportCategoryButton("Футбол");
            button.Click();
            button.FindElement(By.XPath("//label[@class='title' and normalize-space(text())='Австралия']")).Click();
            Driver.FindElement(
                    By.XPath("//label[@class='title' and text()[contains(.,'Виктория. Национальная Премьер-лига')]]"))
                .Click();
            ClickOnEvent();
            return this;
        }

        public SettlementMonitorPage SelectEtapSobitiya()
        {
            Driver.FindElement(By.XPath("//div[@class='bo-multiselect settlement-multiselect'][3]//*[@class = 'multiselect__select']")).Click();
            Driver.FindElement(By.XPath("//*[text()='Finished']")).Click();
            return this;
        }

        public EventProvider SelectEvent()
        {
            var element = "//section[@class='settlement-event-list pinned']//div[@class='alerts-block']//i['warning']";
            Wait.UntilPageIsReady(elementToBeReady:element, baseTimeOut: 15);
            return new EventProvider 
            {

                eventTime = Driver
                    .FindElement(By.XPath(
                        "//section[@class='settlement-event-list pinned']//div[@class='event-time']")).Text,
                eventDate = Driver
                    .FindElement(By.XPath(
                        "//section[@class='settlement-event-list pinned']//div[@class='event-date']")).Text,
                eventName = Driver
                    .FindElement(By.XPath(
                        "//section[@class='settlement-event-list pinned']//div[@class='event-title has-tooltip']"))
                    .Text,
                eventDescription = Driver
                    .FindElement(By.XPath(
                        "//section[@class='settlement-event-list pinned']//div[@class='event-description has-tooltip']"))
                    .Text,
                eventAlert = Driver
                    .FindElement(By.XPath(
                        "//section[@class='settlement-event-list pinned']//div[@class='alerts-block']//i['warning']"))
                    .Text,
                eventStage = Driver
                    .FindElement(By.XPath(
                        "//section[@class='settlement-event-list pinned']//div[@class='event-stage']//div[@class='column score']//span[@class]"))
                    .Text,
                eventScore = Driver
                    .FindElement(By.XPath(
                        "//section[@class='settlement-event-list pinned']//div[@class='scoreBoard']//div[@class='column score']//span[@class]"))
                    .Text,
                eventSettlementState = Driver
                    .FindElement(By.XPath(
                        "//section[@class='settlement-event-list pinned']//section[@class='event-settlement-state']/span[2]"))
                    .Text
            };
        }

        public SettlementMonitorPage InputEventName(string eventName)
        {
            Driver.FindElement(By.XPath("//input[@placeholder ='Найти событие']")).SendKeys(eventName);
            return this;
        }


        public SettlementMonitorPage ClickOnBetInfo()
        {
            Driver.FindElement(By.XPath("//section[@class='event-bet-table-wrapper']//div/table[@class='mn-table bet-table']//tr[1]//button[@class='transparent icon']")).Click();
            return this;
        }

        public BetInfoProvider GetBetinfo()

        {
            return new BetInfoProvider
            {
                eventTime = Driver.FindElement(By.XPath("//table[@class='mn-table']/tbody//tr[1]//td[1]")).Text,
                betStatus = Driver.FindElement(By.XPath("//table[@class='mn-table']/tbody//tr[1]//td[2]")).Text,
                betResult = Driver.FindElement(By.XPath("//table[@class='mn-table']/tbody//tr[1]//td[3]")).Text,
                resultSource = Driver.FindElement(By.XPath("//table[@class='mn-table']/tbody//tr[1]//td[4]")).Text,
                eventName = Driver.FindElement(By.XPath("//table[@class='mn-table']/tbody//tr[1]//td[5]")).Text,
                marketName = Driver.FindElement(By.XPath("//table[@class='mn-table']/tbody//tr[1]//td[6]")).Text,
                comment = Driver.FindElement(By.XPath("//table[@class='mn-table']/tbody//tr[1]//td[7]")).Text
            };
        }
    }
}
