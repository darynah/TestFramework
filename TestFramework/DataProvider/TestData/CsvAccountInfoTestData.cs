using System;
using System.Collections.Generic;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using NUnit.Framework;

namespace TestFramework.DataProvider.TestData
{
    public static class CsvAccountInfoTestData
    {
        public static IEnumerable<TestCaseData> GetAccountInfoData()
        {
            using (var csv = new CsvReader(new StreamReader($"DataProvider/CsvData/login.csv"), true))
            {
                while (csv.ReadNextRecord())
                {
                    string login = csv[0];
                    string password = csv[1];
                    string firstName = csv[2];
                    string lastName = csv[3];
                    string city = csv[4];
                    string email = csv[5];
                    yield return new TestCaseData(
                            new LoginProvider()
                            {
                                Login = login,
                                Password = password
                            },
                            new ExpectedAccountInfoResponceProvider()
                            {
                                Firstname = firstName,
                                LastName = lastName,
                                City = city,
                                Email = email
                            })
                        .SetName($"{lastName} test");
                }
            }
        }

    }
}