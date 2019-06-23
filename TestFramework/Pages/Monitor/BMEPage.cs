using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestFramework.Pages
{
    public class BMEPage : BasePage
    {
        private IWebElement GetSubmitButton => Driver.FindElement(By.XPath("//button[@type='submit']"));
        private IWebElement GetFilterArrowButton(string sectionName) =>
            Driver.FindElement(By.XPath($"//div[@class='form-row' and sectionName ='{sectionName}']//div[@class ='multiselect__select']"));

        public BMEPage GoToPage()
        {
            Driver.Url =
                "http://backoffice.kube.private/monitors/bets?tradingTypeId=&sport=&currency=&playerId=&betType=&resultId=&afs=&channel=&segmentIds=&traderIds=&categoryIds=&betSize=&eventType=&marketIds=&period=&tournament=&team=&value=&betTime=%D0%9F%D1%80%D0%B8%D0%B5%D0%BC&unsettledDuration=&acceptTimeFrom=1560546000000&timestamp=1560620247464";
            return this;
        }

        public BMEPage GoToPageFilter()
        {
            Driver.Url =
                "http://backoffice.kube.private/monitors/bets?tradingTypeId=&sport=&currency=&playerId=087210296&betType=&resultId=&afs=&channel=&segmentIds=&traderIds=&categoryIds=&betSize=&eventType=&marketIds=&period=&tournament=&team=&value=&betTime=%D0%9F%D1%80%D0%B8%D0%B5%D0%BC&unsettledDuration=&acceptTimeFrom=1559338200000&acceptTimeTo=1559597400000&timestamp=1560627400695";
            return this;
        }

        public BMEPage ClickSubmit()
        {
            GetSubmitButton.Click();
            return this;
        }

        public BMEPage ClickonFilterArrow(string sectionName)
        {
            MoveToElement(GetFilterArrowButton(sectionName)).Click();
            return this;
        }


        public BMEPage Filter(string label, string segment)
        {
            var arrow = $"//div[@class='form-row' and label ='{label}']//span[@class ='multiselect__single']";
            Wait.UntilPageIsReady(elementToBeReady: arrow);
            var optionBlockXpath =
                $"//div[@class='multiselect__content-wrapper' and not(contains(@style,'display: none;'))]";
            var arrowXPAth = Driver.FindElement(By.XPath(arrow));
            MoveToElement(arrowXPAth).Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(2000));
            var optionBlock =
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(optionBlockXpath)));
            optionBlock.FindElement(By.XPath($".//span[text()='{segment}']/..")).Click();
            return this;
        }

        public BMEPage FilterByDate(string dateFrom, string dateTo)
        {
            var inputFrom =
                Driver.FindElement(By.XPath(
                    "//div[@class='form-row' and label ='Время приема']//div[@class='custom-frame-from']//input"));
            inputFrom.SendKeys(Keys.Control + "a");
            inputFrom.SendKeys(Keys.Delete);
            inputFrom.SendKeys(dateFrom);
            Driver.FindElement(
                    By.XPath(
                        "//div[@class='form-row' and label ='Время приема']//div[@class='custom-frame-to']//input"))
                .SendKeys(dateTo);
            Driver.FindElement(By.XPath("//label[@class='field-title']")).Click();
            return this;
        }

        public BMEPage InsertPlayerID(string playerId)
        {
            var baseDropdown = "//div[contains(@class,'bo-player-id')]";
            Driver.FindElement(By.XPath(baseDropdown + "//input[contains(@placeholder, 'ID')]/..")).Click();
            Driver.FindElement(By.XPath(baseDropdown + "//input[contains(@placeholder, 'ID')]")).SendKeys(playerId);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(2000));
            var suggestBlock = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .ElementExists(By.XPath(baseDropdown +
                                        "//div[not(contains(@style,'display: none'))]/ul[contains(@class,'multiselect__content')]")));
            suggestBlock.FindElement(By.XPath("./li[@class='multiselect__element']")).Click();
            return this;
        }

        

        public bool PlayerIdAll(string playerID)
        {
            var collectionAdress = GetColumnAdress("playerId");
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

        public bool AcceptTimeAll(string actualDateString)
        {
            DateTime actualDate = DateTime.Parse(actualDateString, CultureInfo.CreateSpecificCulture("de-DE"));
            List<DateTime> collection = new List<DateTime>();
            var collectionAdress = GetColumnAdress("betAcceptTime");
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

        public List<string> EventNameAll() 
        {
            List<string> collection = new List<string>();
            var collectionAdress = GetColumnAdress("eventName");
            Wait.UntilPageIsReady(elementToBeReady: collectionAdress);
            var table = GetBetViewTableData(collectionAdress);
            foreach (IWebElement element in table)
            {
                collection.Add(element.Text);
            }
            return collection;
        }


        public string GetColumnAdress(string columnName)
        {
             string tableColumnAdress 
                = $"//div[@class='bet-view-table-wrapper current']//table[@id='betViewTable']//td[@class='bet-view-table-cell {columnName}']//div";
            return tableColumnAdress;
        }
        public ReadOnlyCollection<IWebElement> GetBetViewTableData (string tableColumnAdress)
        {
            ReadOnlyCollection<IWebElement> links = Driver.FindElements(By.XPath(tableColumnAdress));
            return links;
        }

    }
}
