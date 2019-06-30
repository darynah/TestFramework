using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using TestFramework.DataProvider;

namespace TestFramework.Pages
{
    public class PlayerHistoryPage : BasePage
    {
        private string ActiveTabXpath = "//li[@class='link-active']/a[text()]";
        private IWebElement BetAcceptedTimeFirstCell => Driver.FindElement(By.XPath("//div[@class='bo-table']/div[2]/div[1]/table/tbody/tr[1]/td[@class='betAcceptTime']"));
        private IWebElement ChannelFirstCell => Driver.FindElement(By.XPath("//div[@class='bo-table']/div[2]/div[1]/table/tbody/tr[1]/td[@class='channel']"));
            
        public PlayerHistoryPage GotoPage()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            return this;
        }
        public bool IsActiveTabEquals(string expectedTabName)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(5000));
            var activeTab = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .ElementExists(By.XPath(ActiveTabXpath)));
            return activeTab.Text.Trim().Equals(expectedTabName);
        }
       
        public BetInfoPlayerHistoryModel GetBetInfoFromPlayerHistory()
        {
            return new BetInfoPlayerHistoryModel
            {
                BetAcceptTime = BetAcceptedTimeFirstCell.Text,
                Channel = ChannelFirstCell.Text,
            };
        }
    }
}