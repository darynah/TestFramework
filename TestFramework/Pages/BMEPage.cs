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

        public BMEPage ClickonFilterArrow(string sectionName)
        {
            var arrow =
                $"//div[@class='form-row' and sectionName ='{sectionName}']//div[@class ='multiselect__select']";
            var arrowXPAth = Driver.FindElement(By.XPath(arrow));
            MoveToElement(arrowXPAth).Click();
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
            inputFrom.SendKeys(Keys.Control+"a");
            inputFrom.SendKeys(Keys.Delete);
            inputFrom.SendKeys(dateFrom);
            Driver.FindElement(By.XPath("//div[@class='form-row' and label ='Время приема']//div[@class='custom-frame-to']//input")).SendKeys(dateTo);
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

        public BMEPage Submit()
        {
            Driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            return this;
        }

        public bool PlayerIdAll(string playerID)
        {
            var collectionAdress =
                "//div[@class='bet-view-table-wrapper current']//table[@id='betViewTable']//td[@class='bet-view-table-cell playerId']//span";
            Wait.UntilPageIsReady(3, collectionAdress);
            List<string> matchingLinks = new List<string>();
            ReadOnlyCollection<IWebElement> links = Driver.FindElements(By.XPath(collectionAdress));
            foreach (IWebElement link in links)
            {
                string text = link.Text;
                matchingLinks.Add(text);
            }

            bool flag = true;

            for (int i = 0; i < matchingLinks.Count; i++)
            {
                if (matchingLinks[i] != playerID)
                {
                    return flag = false;
                }
            }

            return flag;
        }

        public bool AcceptTimeAll(string actualDateString)
        {
            DateTime actualDate = DateTime.Parse(actualDateString, CultureInfo.CreateSpecificCulture("de-DE"));
            List<DateTime> matchingLinks = new List<DateTime>();
            ReadOnlyCollection<IWebElement> links = Driver.FindElements(By.XPath(
                "//div[@class='bet-view-table-wrapper current']//table[@id='betViewTable']//td[@class='bet-view-table-cell betAcceptTime']//div"));
            foreach (IWebElement link in links)
            {
                string text = link.Text.Replace("\r\n", " ");
                DateTime acceptedDate = DateTime.Parse(text, CultureInfo.CreateSpecificCulture("de-DE"));
                matchingLinks.Add(acceptedDate);
            }

            bool flag = true;

            for (int i = 0; i < matchingLinks.Count; i++)
            {
                if (matchingLinks[i] < actualDate)
                {
                    return flag = false;
                }
            }

            return flag;
        }
    }
}
