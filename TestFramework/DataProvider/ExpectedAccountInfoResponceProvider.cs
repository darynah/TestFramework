using TestFramework.DataProvider.Model;

namespace TestFramework.DataProvider
{
    public class ExpectedAccountInfoResponceProvider : IAccountInfoModel
    {
        public string Firstname { get; set; } = "Daryna";
        public string LastName { get; set; } = "Horobets_";
        public string City { get; set; } = "Kiev";
        public string Email { get; set; } = "darina2@mailforspam.com";
    }
}