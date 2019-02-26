using NUnit.Framework;
using TestFramework.DataProvider;
using TestFramework.DataProvider.TestData;
using TestFramework.Pages;

namespace TestFramework.Tests
{
    public class RegistrationTest : _BaseUITest
    {
        public RegistrationPage _registrationPage;
        [SetUp]
        public void BeforeTest()
        {
            _registrationPage = new RegistrationPage();
        }

        [TestCaseSource(typeof(RegistrationTestData), nameof(RegistrationTestData.GetUserData))]
        public void Register(UserProvider userData)
        {
        
            _registrationPage
                .InsertEmail(userData.Email)
                .SelectBirthDay(userData.Year, userData.Month, userData.Day)
                .SelectCurrency(userData.Currency)
                .InsertPassword(userData.Password)
                .SubmitRegistration();

            Assert.AreEqual(userData.Email,_registrationPage.GetRegistredEmail());
        }
    }
}