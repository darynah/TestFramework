using NUnit.Framework;
using TestFramework.DataProvider;
using TestFramework.DataProvider.TestData;
using TestFramework.Pages;

namespace TestFramework.Tests
{
    public class RegistrationTest : _BaseUITest
    {
        [TestCaseSource(typeof(RegistrationTestData), nameof(RegistrationTestData.GetUserData))]
        public void Register(UserProvider userData)
        {
            RegistrationPage registrationPage = new RegistrationPage();
            registrationPage.InsertEmail(userData.Email);
            registrationPage.SelectBirthDay(userData.Year, userData.Month, userData.Day);
            registrationPage.SelectCurrency(userData.Currency);
            registrationPage.InsertPassword(userData.Password);
            registrationPage.SubmitRegistration();

            Assert.AreEqual(userData.Email,registrationPage.GetRegistredEmail());
        }
    }
}