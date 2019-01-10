using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TestFramework.DataProvider;
using TestFramework.DataProvider.Model;
using TestFramework.Utils;
using TestFramework.Utils.Extensions;

namespace TestFramework.Requests

{
    public class SkeletonRequest
    {
        private ApiClient _pmClient;
        private string _token = null;

        public SkeletonRequest()
        {
            _pmClient = new ApiClient("http://air-pm-skeleton-bl.hp.consul");
        }

        public void Authorize(LoginProvider login)
        {
            _token = TokenManager.Authorize(login);
        }

        public IAccountInfoModel GetAccountInfo()
        {
            var response = _pmClient.Get("/api/v2/User/GetAccountInfo", _token);
            response.CheckHttpCode("Cannot get Account info");
            var result = response.Content.ReadAsStringAsync().Result;
            result.CheckIfNull("Responce from GetAccountInfoIsNull");
            return ParseAcccountInfoResponce(result);
        }

        private IAccountInfoModel ParseAcccountInfoResponce(string result)
        {
            var resultJObject = JsonConvert.DeserializeObject<JObject>(result);
            return new ExpectedAccountInfoResponceProvider()
            {
                Firstname = resultJObject["firstName"].ToString(),
                LastName = resultJObject["lastName"].ToString(),
                City = resultJObject["city"].ToString(),
                Email = resultJObject["email"].ToString()
            };
        }
    }
}
