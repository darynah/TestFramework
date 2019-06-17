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
    public class SettlementMonitorRequest
    {
        private ApiClient _client;
        private string _token = null;

        public SettlementMonitorRequest()
        {

            _client = new ApiClient("http://bet-view-new.kube.private");
        }

        public void AuthorizeInMonitor(LoginProviderMonitor login)
        {
            _token = TokenManager.AuthorizeMonitor(login);
        }

        public async Task<List<string>> RequestBetViewBets()
        {
            var reguesttext = new BetViewBetsRequestModel();
            var responce = await _client.PostWithToken("/bets", _token, JsonConvert.SerializeObject(reguesttext));
            var contents = responce;
            var resultObject = JsonConvert.DeserializeObject<List<BetViewBetsResponceModel>>(contents);
            var eventId = new List<string>();
            foreach (var element in resultObject)
            {
                eventId.Add(element.eventId);
            }

            return eventId;
        }
    }
}