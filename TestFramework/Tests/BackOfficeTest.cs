using NUnit.Framework;
using TestFramework.DataProvider;
using TestFramework.DataProvider.TestData;
using TestFramework.Requests;

namespace TestFramework.Tests
{
    
    public class BackOfficeTest
    {
        private SkeletonRequest _myLoginPage;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _myLoginPage = new SkeletonRequest();
        }

        [TestCaseSource(typeof(CsvAccountInfoTestData), nameof(CsvAccountInfoTestData.GetAccountInfoData))]
        public void CheckAccountInfo(LoginProvider loginProvider, ExpectedAccountInfoResponceProvider expectedProvider)
        {
            _myLoginPage.Authorize(loginProvider);
            var actualResponce = _myLoginPage.GetAccountInfo();
            Assert.Multiple(() =>
                {
                    Assert.AreEqual(expectedProvider.City, actualResponce.City);
                    Assert.AreEqual(expectedProvider.Email, actualResponce.Email);
                    Assert.AreEqual(expectedProvider.Firstname, actualResponce.Firstname);
                    Assert.AreEqual(expectedProvider.LastName, actualResponce.LastName);
                }
            );
        }
    }
}