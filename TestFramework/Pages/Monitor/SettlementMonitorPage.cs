using System.Linq;
using OpenQA.Selenium;
using TestFramework.DataProvider;

namespace TestFramework.Pages.Monitor
{
    public class SettlementMonitorPage : BasePage
    {
        private string CloseDashboardXpath =
            "//section[@class='settlement-dashboard']//button[@class='icon transparent close-button']";

        private IWebElement GetSportCategoryButton(string sportName) =>
            Driver.FindElement(By.XPath($"//label[@class='title' and normalize-space(text())='{sportName}']"));
        private IWebElement CloseDashboaradButton =>
            Driver.FindElement(By.XPath(CloseDashboardXpath));
        private IWebElement GetCalendarIcon => Driver.FindElement(By.ClassName("mx-calendar-icon"));
        private IWebElement GetCalendarDate(string date) =>
            Driver.FindElement(By.XPath($"//td[@title='{date}' and@class='cell cur-month']"));
        private IWebElement GetCalendarRefresh =>
            Driver.FindElement(By.XPath("//button[@class='link transparent refresh']"));
        private IWebElement GetEvenTreeCheckbox => 
            Driver.FindElement(By.XPath("//span[@class='material-icons']"));
        private IWebElement GetPinnedEvent =>
            Driver.FindElement(By.XPath("//section[@class='settlement-event-list pinned']//div[@class='alert-item'][1]"));
        private IWebElement PinnedElementBlock =>
            Driver.FindElement(By.XPath("//section[@class='settlement-event-list pinned']"));
        private IWebElement BetLogsPopup =>
            Driver.FindElement(By.XPath("//tr[@class='bo-table-row'][1]"));

        public SettlementMonitorPage GoPage()
        {
            Driver.Url =
                "http://backoffice.kube.private/monitors/settlement?betSettlementFilterFrom=1559854800000&betSettlementFilterTo=1559941199999";
            return this;
        }

        public SettlementMonitorPage CloseDashboard()
        {
            Wait.UntilPageIsReady(3);
            var CloseDashBoardButton = Driver.FindElements(By.XPath(CloseDashboardXpath));
            var elementExist = (CloseDashBoardButton.Count >= 1) ? CloseDashBoardButton.First() : null;
            if (elementExist !=null)
            {
                Driver.FindElement(By.XPath(CloseDashboardXpath)).Click();
            }
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
            GetCalendarIcon.Click();
        }

        private void ClickOnCalendarDate(string date)
        {
            GetCalendarDate(date).Click();
            GetCalendarRefresh.Click();
        }

        public SettlementMonitorPage ClickOnEvent()
        {
            GetEvenTreeCheckbox.Click();
            return this;
        }

        public SettlementMonitorPage ClickOnEventInRightPanel()
        {
            GetPinnedEvent.Click();
            return this;
        }

        public SettlementMonitorPage RefreshEvenTree()
        {
            Driver.FindElement(By.XPath("//button[@class='link transparent refresh']")).Click();
            return this;
        }

        public SettlementMonitorPage ClickOnEventInEventTree( string sportName, string category, string tournament)
        {
            var button = GetSportCategoryButton(sportName);
            button.Click();
            button.FindElement(By.XPath($"//label[@class='title' and normalize-space(text())='{category}']")).Click();
            Driver.FindElement(
                    By.XPath($"//label[@class='title' and text()[contains(.,'{tournament}')]]"))
                .Click();
            ClickOnEvent();
            return this;
        }

        public SettlementMonitorPage SelectEtapSobitiya(string etap)
        {
            Driver.FindElement(By.XPath("//div[@class='bo-multiselect settlement-multiselect'][3]//*[@class = 'multiselect__select']")).Click();
            Driver.FindElement(By.XPath($"//*[text()='{etap}']")).Click();
            return this;
        }

        public EventProvider SelectEvent()
        {
            var element = "//section[@class='settlement-event-list pinned']//div[@class='alerts-block']//i['warning']";
            Wait.UntilPageIsReady(elementToBeReady: element, baseTimeOut: 15);
            return new EventProvider
            {

                EventTime = PinnedElementBlock.FindElement(By.XPath(".//div[@class='event-time']")).Text,
                EventDate = PinnedElementBlock.FindElement(By.XPath(".//div[@class='event-date']")).Text,
                EventName = PinnedElementBlock.FindElement(By.XPath(".//div[@class='event-title has-tooltip']")).Text,
                EventDescription = PinnedElementBlock.FindElement(By.XPath(".//div[@class='event-description has-tooltip']")) .Text,
                EventAlert = PinnedElementBlock.FindElement(By.XPath(".//div[@class='alerts-block']//i['warning']")).Text,
                EventStage = PinnedElementBlock.FindElement(By.XPath(".//div[@class='column score']//span[@class]")).Text,
                EventScore = PinnedElementBlock.FindElement(By.XPath(".//div[@class='scoreBoard']//div[@class='column score']//span[@class]")).Text,
                EventSettlementState = 
                    Driver.FindElement(By.XPath("//section[@class='settlement-event-list pinned']//section[@class='event-settlement-state']/span[2]")).Text
            };
        }

        public SettlementMonitorPage InputEventName(string eventName)
        {
            Driver.FindElement(By.XPath("//input[@placeholder ='Найти событие']")).SendKeys(eventName);
            return this;
        }


        public SettlementMonitorPage ClickOnBetInfo()
        {
            Wait.UntilElementReady(Driver,By.XPath(
                "//section[@class='event-bet-table-wrapper']//div/table[@class='mn-table bet-table']//tr[1]//button[@class='transparent icon']"),2000);
            Driver.FindElement(By.XPath("//section[@class='event-bet-table-wrapper']//div/table[@class='mn-table bet-table']//tr[1]//button[@class='transparent icon']")).Click();
            return this;
        }

        public BetInfoProvider GetBetinfo()
        
        {
            
            return new BetInfoProvider
            {
                EventTime = BetLogsPopup.FindElement(By.XPath("./td[@class='settlementTime']")).Text,
                BetStatus = BetLogsPopup.FindElement(By.XPath("./td[@class='status']")).Text,
                BetResult = BetLogsPopup.FindElement(By.XPath("./td[@class='result']")).Text,
                ResultSource = BetLogsPopup.FindElement(By.XPath("./td[@class='operator']")).Text,
                EventName = BetLogsPopup.FindElement(By.XPath("./td[@class='eventName']")).Text,
                MarketName = BetLogsPopup.FindElement(By.XPath("./td[@class='market']")).Text,
                Comment = BetLogsPopup.FindElement(By.XPath("./td[@class='settlementComment']")).Text,
            };
        }
    }
}