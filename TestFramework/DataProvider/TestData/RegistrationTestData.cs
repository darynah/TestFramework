using System.Collections.Generic;
using NUnit.Framework;

namespace TestFramework.DataProvider.TestData
{
    public static class RegistrationTestData
    {
        public  static IEnumerable<TestCaseData> GetUserData()
        {
            yield return new TestCaseData(new UserProvider()); 
        }
    }
}