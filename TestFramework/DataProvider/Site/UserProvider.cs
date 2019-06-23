using System;
using TestFramework.DataProvider.Model;

namespace TestFramework.DataProvider
{
    public class UserProvider : IUserModel
    {
        public string Email { get; }
        public string Day { get; } = "01";
        public string Month { get; } = "12";
        public string Year { get; } = "1989";
        public string Currency { get; } = "3";
        public string Password { get; } = "12345633_AA";

        public UserProvider()
        {
            Email = $"ppwppp+{Guid.NewGuid()}@mailforspam.com";
        }
    }
}