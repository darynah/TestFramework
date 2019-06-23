using System;
using System.Collections.Generic;

namespace TestFramework.Requests
{
    public class BetViewBetsResponceModel
    {
        public string Id { get; set; }
        public string PlayerId { get; set; }
        public string EventId { get; set; }
        public string TournamentName { get; set; }
        public string EventName { get; set; }
        public string MarketName { get; set; }
        public string SportName { get; set; }
        public DateTime StartTime { get; set; }
    }
}