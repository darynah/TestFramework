using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using TestFramework.DataProvider;
using TestFramework.DataProvider.Model;
using TestFramework.Utils;

namespace TestFramework.Requests
{
    public class BetViewRequest
    {
        private ApiClient _client;
        private string _token = null;

        public BetViewRequest()
        {
            _client = new ApiClient("http://bet-view-new.kube.private");
        }

        public void AuthorizeInMonitor(LoginProviderMonitor login)
        {
            _token = TokenManager.AuthorizeMonitor(login);
        }

        public  List<string> RequestBetViewBets()
        {
            var reguesttext = new BetViewBetsRequestModel();
            var responce =  _client.PostWithToken("/bets", _token, JsonConvert.SerializeObject(reguesttext));
            var resultObject = JsonConvert.DeserializeObject<List<BetViewBetsResponceModel>>(responce);
            var eventId = new List<string>();
            foreach (var element in resultObject)
            {
                eventId.Add(element.EventName);
            }

            return eventId;
        }
    }
}