using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestFramework.DataProvider;

namespace TestFramework.Pages
{
    public class PlayerHistoryPage : _BasePage
    {
        public PlayerHistoryPage GotoPage()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            return this;
        }
        public bool IsActiveTabEquals(string expectedTabName)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(5000));
            var activeTab = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .ElementExists(By.XPath("//li[@class='link-active']/a[text()]")));
            return activeTab.Text.Trim().Equals(expectedTabName);
        }
       

        public BetInfoPlayerHistoryProvider GetBetInfoFromPlayerHistory()
        {
            return new BetInfoPlayerHistoryProvider
            {
                betAcceptTime = _driver.FindElement(By.XPath("//div[@class='bo-table']/div[2]/div[1]/table/tbody/tr[1]/td[@class='betAcceptTime']")).Text,
                //betNumber = _driver.FindElement(By.XPath("//div[@class='bo-table']/div[2]/div[1]/table/tbody/tr[1]/td[@class='betNumber']")).Text,
                channel = _driver.FindElement(By.XPath("//div[@class='bo-table']/div[2]/div[1]/table/tbody/tr[1]/td[@class='channel']")).Text,
                //eventStartTime = _driver.FindElement(By.XPath("//div[@class='bo-table']/div[2]/div[1]/table/tbody/tr[1]/td[@class='eventStartTime']")).Text,
                //eventDescription = _driver.FindElement(By.XPath("//div[@class='bo-table']/div[2]/div[1]/table/tbody/tr[1]/td[@class='eventDescription']")).Text,
                //eventName = _driver.FindElement(By.XPath("//div[@class='bo-table']/div[2]/div[1]/table/tbody/tr[1]/td[@class='eventName']")).Text,
                //score = _driver.FindElement(By.XPath("//div[@class='bo-table']/div[2]/div[1]/table/tbody/tr[1]/td[@class='score']")).Text,
                //market = _driver.FindElement(By.XPath("//div[@class='bo-table']/div[2]/div[1]/table/tbody/tr[1]/td[@class='market']")).Text,
                //selection = _driver.FindElement(By.XPath("//div[@class='bo-table']/div[2]/div[1]/table/tbody/tr[1]/td[@class='selection']")).Text,
                //betOdd = _driver.FindElement(By.XPath("//div[@class='bo-table']/div[2]/div[1]/table/tbody/tr[1]/td[@class='betOdd']")).Text,
                //betAmount = _driver.FindElement(By.XPath("//div[@class='bo-table']/div[2]/div[1]/table/tbody/tr[1]/td[@class='betAmount']")).Text,
                //resultMark = _driver.FindElement(By.XPath("//div[@class='bo-table']/div[2]/div[1]/table/tbody/tr[1]/td[@class='resultMark']")).Text,
                //payoutAmount = _driver.FindElement(By.XPath("//div[@class='bo-table']/div[2]/div[1]/table/tbody/tr[1]/td[@class='payoutAmount']")).Text,
                //profit = _driver.FindElement(By.XPath("//div[@class='bo-table']/div[2]/div[1]/table/tbody/tr[1]/td[@class='profit']")).Text,
                //trader = _driver.FindElement(By.XPath("//div[@class='bo-table']/div[2]/div[1]/table/tbody/tr[1]/td[@class='trader']")).Text,
                //playerIp = _driver.FindElement(By.XPath("//div[@class='bo-table']/div[2]/div[1]/table/tbody/tr[1]/td[@class='playerIp']")).Text,
                //afsId = _driver.FindElement(By.XPath("//div[@class='bo-table']/div[2]/div[1]/table/tbody/tr[1]/td[@class='afsId']")).Text
            };
        }
    }
}
