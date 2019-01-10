using TestFramework.DataProvider.Model;

namespace TestFramework.DataProvider
{
    public class ExpectedAccountInfoResponceProvider : IAccountInfoModel
    {
        public string Firstname { get; set; } = "Daryna";
        public string LastName { get; set; } = "Horobets";
        public string City { get; set; } = "Kyiv";
        public string Email { get; set; } = "darina2@mailforspam.com";
    }
}