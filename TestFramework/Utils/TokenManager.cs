using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using TestFramework.DataProvider;

namespace TestFramework.Utils
{
    public static class TokenManager
    {
        //[ThreadStatic]
        //private static string _token;

        //public static string GetToken(LoginProvider login)//
        //{
        //    if (string.IsNullOrEmpty(_token))//
        //    {
        //        _token = Authorize(login);
        //        return _token;
        //    }
        //    return _token;
        //}

        public static string Authorize(LoginProvider login)//
        {
            ApiClient pmClient = new ApiClient("http://air-pm-skeleton-bl.hp.consul");

            var response = pmClient.Post("/api/login", JsonConvert.SerializeObject(login));//
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Authorization is not success");
            }
            var result = response.Content.ReadAsStringAsync().Result;
            var resultJObject = JsonConvert.DeserializeObject<JObject>(result);
            var token = resultJObject["token"].ToString();
            return token;
        }
    }
}
