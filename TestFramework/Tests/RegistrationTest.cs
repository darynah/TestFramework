using NUnit.Framework;
using TestFramework.Pages;

namespace TestFramework.Tests
{
    public class RegistrationTest : _BaseUITest
    {
        [Test]
        public void Registr()
        {
            RegistrationPage registrationPage = new RegistrationPage();
            registrationPage.InsertEmail("ppp@mailforspam.com");
            registrationPage.SelectBirthDay(1789,12,22);
            registrationPage.SelectCurrency("3");
            registrationPage.InsertPassword("123456");
            registrationPage.SubmitRegistration();
        }
    }
}