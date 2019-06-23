using System.Collections.ObjectModel;
using OpenQA.Selenium;
using TestFramework.Pages;

namespace TestFramework.Utils
{
    public class GetCollectionFromUI : BasePage
    {
        public ReadOnlyCollection<IWebElement> GetBetViewTableData(string tableColumnAdress)
        {
            ReadOnlyCollection<IWebElement> links = Driver.FindElements(By.XPath(tableColumnAdress));
            return links;
        }
    }
}