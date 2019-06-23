using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestFramework.DataProvider
{
    public class BetViewBetsRequestModel
    {
        [JsonProperty(PropertyName = "inFilter")]
        public InFilter InFilter  = new InFilter();
        [JsonProperty(PropertyName = "oDataFilter")]
        public string ODataFilter { get; set; } =
            "(acceptTime le 2019-06-03T21:00:00.000Z) and (acceptTime ge 2019-05-31T21:00:00.000Z)";
        [JsonProperty(PropertyName = "take")]
        public int Take { get; set; } = 50;
    }

    public class InFilter
    {
        public string[] Sports { get; set; } = new string[] {};
        public string[] CategoryIds { get; set; } = new string[] { };
        public string[] TournamentIds { get; set; } = new string[] { };
        public string[] BetTypes { get; set; } = new string[] { };
        public string[] SegmentIds { get; set; } = new string[] { };
        public string[] Currencies { get; set; } = new string[] { };
        public string[] PlayerIds { get; set; } = new string[] { "087210296" };
        public string[] ResultIds { get; set; } = new string[] { };
        public string[] AfsIds { get; set; } = new string[] { };
        public string[] TraderIds { get; set; } = new string[] { };
        public string[] Channels { get; set; } = new string[] { };
    }

}