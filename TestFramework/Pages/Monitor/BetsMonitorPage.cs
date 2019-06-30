using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestFramework.Pages
{
    public class BetsMonitorPage : BasePage
    {
        private IWebElement GetSubmitButton => Driver.FindElement(By.XPath("//button[@type='submit']"));
        private IWebElement GetFilterArrowButton(string sectionName) => Driver.FindElement(By.XPath( $"//div[@class='form-row' and sectionName ='{sectionName}']//div[@class ='multiselect__select']"));
        private IWebElement FilterByDate(string parameter) => Driver.FindElement(By.XPath( $"//div[@class='form-row' and label ='Время приема']//div[@class='custom-frame-{parameter}']//input"));
        private IWebElement GetFilterSection => Driver.FindElement(By.XPath("//label[@class='field-title']"));
        private IWebElement FilterByPlayerInput => Driver.FindElement(By.XPath("//div[contains(@class,'bo-player-id')]"));

        private string FilterDropdownIsEmptyXpath => "//div[contains(@class,'bo-player-id')]//div[not(contains(@style,'display: none'))]/ul[contains(@class,'multiselect__content')]";
        private string FilterCloseDropdownXpath => "./li[@class='multiselect__element']";
        private string FilterDropdownXpath => $"//div[@class='multiselect__content-wrapper' and not(contains(@style,'display: none;'))]";
        private string FilterElementInDropdownXpath(string segment) => $".//span[text()='{segment}']/..";
        private string GetColumnAdressXpath(string columnName) => $"//div[@class='bet-view-table-wrapper current']//table[@id='betViewTable']//td[@class='bet-view-table-cell {columnName}']//div";
        private string FilterArrowXpath(string label) => $"//div[@class='form-row' and label ='{label}']//span[@class ='multiselect__single']";

        public ReadOnlyCollection<IWebElement> GetBetViewTableData(string tableColumnAdress)
        {
            ReadOnlyCollection<IWebElement> links = Driver.FindElements(By.XPath(tableColumnAdress));
            return links;
        }

        public BetsMonitorPage GoToPage()
        {
            Driver.Url =
                "http://backoffice.kube.private/monitors/bets?tradingTypeId=&sport=&currency=&playerId=&betType=&resultId=&afs=&channel=&segmentIds=&traderIds=&categoryIds=&betSize=&eventType=&marketIds=&period=&tournament=&team=&value=&betTime=%D0%9F%D1%80%D0%B8%D0%B5%D0%BC&unsettledDuration=&acceptTimeFrom=1560546000000&timestamp=1560620247464";
            return this;
        }

        public BetsMonitorPage ClickSubmitInFilter()
        {
            GetSubmitButton.Click();
            return this;
        }

        public BetsMonitorPage ClickonFilterArrow(string sectionName)
        {
            MoveToElement(GetFilterArrowButton(sectionName)).Click();
            return this;
        }

        public BetsMonitorPage FilterByItem(string label, string segment)
        {
            Wait.UntilPageIsReady(elementToBeReady: FilterArrowXpath(label));
            var arrowXPAth = Driver.FindElement(By.XPath(FilterArrowXpath(label)));
            MoveToElement(arrowXPAth).Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(2000));
            var filterOptionBlock = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(FilterDropdownXpath)));
            filterOptionBlock.FindElement(By.XPath(FilterElementInDropdownXpath(segment))).Click();
            return this;
        }

        public BetsMonitorPage FilterByDate(string dateFrom, string dateTo)
        {
            var inputFrom = FilterByDate("from");
            inputFrom.SendKeys(Keys.Control + "a");
            inputFrom.SendKeys(Keys.Delete);
            inputFrom.SendKeys(dateFrom);
            FilterByDate("to").SendKeys(dateTo);
            GetFilterSection.Click();
            return this;
        }

        public BetsMonitorPage InsertPlayerID(string playerId)
        {
            FilterByPlayerInput.FindElement(By.XPath("//input[contains(@placeholder, 'ID')]/..")).Click();
            FilterByPlayerInput.FindElement(By.XPath("//input[contains(@placeholder, 'ID')]")).SendKeys(playerId);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(2000));
            var suggestBlock = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .ElementExists(By.XPath(FilterDropdownIsEmptyXpath)));
            suggestBlock.FindElement(By.XPath(FilterCloseDropdownXpath)).Click();
            return this;
        }

        public bool ComparePlayerIdForAllElementsWithFilteredValue(string playerID)
        {
            var collectionAdress = GetColumnAdressXpath("playerId");
            Wait.UntilPageIsReady(3, collectionAdress);
            List<string> collection = new List<string>();
            var table = GetBetViewTableData(collectionAdress);
            foreach (IWebElement element in table)
            {
                string text = element.Text;
                collection.Add(text);
            }

            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i] != playerID)
                    return false;
            }
            return true;
        }

        public bool CompareAcceptTimeForAllElementsWithFilteredValue(string actualDateString)
        {
            DateTime actualDate = DateTime.Parse(actualDateString, CultureInfo.CreateSpecificCulture("de-DE"));
            List<DateTime> collection = new List<DateTime>();
            var collectionAdress = GetColumnAdressXpath("betAcceptTime");
            var table = GetBetViewTableData(collectionAdress);
            foreach (IWebElement element in table)
            {
                string text = element.Text.Replace("\r\n", " ");
                DateTime acceptedDate = DateTime.Parse(text, CultureInfo.CreateSpecificCulture("de-DE"));
                collection.Add(acceptedDate);
            }

            for (int i = 0; i < collection.Count; i++)
                if (collection[i] < actualDate)
                    return false;
            return true;
        }

        public List<string> GetEventNameForAllElements()
        {
            List<string> collection = new List<string>();
            var collectionAdress = GetColumnAdressXpath("eventName");
            Wait.UntilPageIsReady(3,elementToBeReady: collectionAdress);
            var table = GetBetViewTableData(collectionAdress);
            foreach (IWebElement element in table)
            {
                collection.Add(element.Text);
            }
            return collection;
        }
    }
}
