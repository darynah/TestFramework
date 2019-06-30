using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using TestFramework.DataProvider;

namespace TestFramework.Utils
{
    public static class TokenManager
    {
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

        public static string AuthorizeMonitor(LoginProviderMonitor login)//
        {
            ApiClient pmClient = new ApiClient("http://backoffice.kube.private");

            var response = pmClient.Post("/api/sso-operator/Login", JsonConvert.SerializeObject(login));//
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