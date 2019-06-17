using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestFramework.DataProvider
{
    public class BetViewBetsRequestModel
    {
        [JsonProperty(PropertyName = "inFilter")]
        public InFilter inFilter  = new InFilter();
        [JsonProperty(PropertyName = "oDataFilter")]
        public string oDataFilter { get; set; } =
            "(acceptTime le 2019-06-03T21:00:00.000Z) and (acceptTime ge 2019-05-31T21:00:00.000Z)";
        [JsonProperty(PropertyName = "take")]
        public int take { get; set; } = 50;
    }

    public class InFilter
    {
        public string[] sports { get; set; } = new string[] {};
        public string[] categoryIds { get; set; } = new string[] { };
        public string[] tournamentIds { get; set; } = new string[] { };
        public string[] betTypes { get; set; } = new string[] { };
        public string[] segmentIds { get; set; } = new string[] { };
        public string[] currencies { get; set; } = new string[] { };
        public string[] playerIds { get; set; } = new string[] { "087210296" };
        public string[] resultIds { get; set; } = new string[] { };
        public string[] afsIds { get; set; } = new string[] { };
        public string[] traderIds { get; set; } = new string[] { };
        public string[] channels { get; set; } = new string[] { };
    }

}