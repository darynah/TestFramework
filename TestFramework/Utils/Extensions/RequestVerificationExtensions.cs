using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TestFramework.Utils.Extensions
{
    public static class RequestVerificationExtensions
    {
        public static void CheckIfNull(this string content, string message)
        {
            if (content == null)
            {
                throw new Exception(message);
            }
        }
        public static void CheckHttpCode(this HttpResponseMessage response, string message)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"{message} code: {response.StatusCode}");
            }
        }
    }
}