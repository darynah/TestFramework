using System;
using System.Collections.Generic;

namespace TestFramework.Requests
{
    public class BetViewBetsResponceModel
    {
        public string id { get; set; }
        public DateTime acceptTime { get; set; }
        public int betAmount { get; set; }
        public double betBaseAmount { get; set; }
        public int betPayout { get; set; }
        public int basePayout { get; set; }
        public int betProfit { get; set; }
        public double baseProfit { get; set; }
        public string brandId { get; set; }
        public string channel { get; set; }
        public string currency { get; set; }
        public int betType { get; set; }
        public string playerId { get; set; }
        public string playerIp { get; set; }
        public int playerProfitStatus { get; set; }
        public int betSize { get; set; }
        public int playerSegmentId { get; set; }
        public int playerBetNumber { get; set; }
        public double acceptedBetOdd { get; set; }
        public int resultId { get; set; }
        public int systemSize { get; set; }
        public object tradingType { get; set; }
        public int afsId { get; set; }
        public object afsLogin { get; set; }
        public DateTime settlementTime { get; set; }
        public int unsettledDuration { get; set; }
        public int settlementStatus { get; set; }
        public bool isManual { get; set; }
        public List<Item> items { get; set; }
        public string selectionKey { get; set; }
        public int eventStageId { get; set; }
        public string trader { get; set; }
        public string originalScore { get; set; }
        public string eventId { get; set; }
        public string lineItemId { get; set; }
        public double acceptedOdd { get; set; }
        public double baseAmount { get; set; }
        public string sport { get; set; }
        public string tournamentId { get; set; }
        public string categoryId { get; set; }
        public int marketId { get; set; }
        public double marketParameter1 { get; set; }
        public int marketParameter2 { get; set; }
        public int marketParameter3 { get; set; }
        public int marketParameter4 { get; set; }
        public int periodValue1 { get; set; }
        public int periodValue2 { get; set; }
        public int periodValue3 { get; set; }
        public int resultKind { get; set; }
        public int selectionId { get; set; }
        public object tradingTypeId { get; set; }
        public object outcomeKey { get; set; }
        public string tournamentName { get; set; }
        public string eventName { get; set; }
        public string marketName { get; set; }
        public string selectionName { get; set; }
        public string sportName { get; set; }
        public DateTime startTime { get; set; }
    }

    public class Item
    {
        public int itemIndex { get; set; }
        public string selectionKey { get; set; }
        public int eventStageId { get; set; }
        public string tradingTypeId { get; set; }
        public string trader { get; set; }
        public string originalScore { get; set; }
        public string eventId { get; set; }
        public string lineItemId { get; set; }
        public double acceptedOdd { get; set; }
        public double baseAmount { get; set; }
        public int resultId { get; set; }
        public string sport { get; set; }
        public string tournamentId { get; set; }
        public string categoryId { get; set; }
        public int marketId { get; set; }
        public double marketParameter1 { get; set; }
        public int marketParameter2 { get; set; }
        public int marketParameter3 { get; set; }
        public int marketParameter4 { get; set; }
        public int periodValue1 { get; set; }
        public int periodValue2 { get; set; }
        public int periodValue3 { get; set; }
        public int resultKind { get; set; }
        public int selectionId { get; set; }
        public string tournamentName { get; set; }
        public string eventName { get; set; }
        public string marketName { get; set; }
        public string selectionName { get; set; }
        public string sportName { get; set; }
        public DateTime startTime { get; set; }
        public bool isResettled { get; set; }
        public object settlementScore { get; set; }
    }
}