using System.Collections.Generic;
using NUnit.Framework;

namespace TestFramework.DataProvider.TestData
{
    public static class AccountInfoTestData
    {
        public static IEnumerable<TestCaseData> GetAccountInfoData()
        {
            yield return new TestCaseData(
                new LoginProvider(),
                new ExpectedAccountInfoResponceProvider()
                ).SetName("DarinaTest");

            yield return new TestCaseData(
                new LoginProvider()
                {
                    Login = "163942205",
                    Password = "QAZxswEDC123!"
                },
                new ExpectedAccountInfoResponceProvider()
                {
                    LastName = "Padalko",
                    Firstname = "Yuriy",
                    City = "Kiev",
                    Email = "yuriy.padalko+9438294@betlab.com"
                }
            ).SetName("YuriyTest");
        }
    }
}