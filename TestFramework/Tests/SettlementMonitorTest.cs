using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using TestFramework.DataProvider;
using TestFramework.Pages;
using TestFramework.Pages.Monitor;
using TestFramework.Requests;
using TestFramework.Utils;
using static TestFramework.DataProvider.ChannelMapper;

namespace TestFramework.Tests
{
    public class SettlementMonitorTest : _BaseUITest
    {
        public BetViewRequest _settlementMonitorRequest;
        public AuthorizationMonitor _authorizationPage;
        public SettlementMonitorPage _settlementMonitorPage;
        public SettlenemtMonitorEventPage _settlenemtMonitorEventPage;
        public PlayerHistoryPage _playerHistoryPage;
        public BMEPage _BMEPage;

        [SetUp]
        public void BeforeTest()
        {
            _settlementMonitorRequest = new BetViewRequest();
            _authorizationPage = new AuthorizationMonitor();
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlenemtMonitorEventPage = new SettlenemtMonitorEventPage();
            _playerHistoryPage = new PlayerHistoryPage();
            _BMEPage = new BMEPage();
        }

        [Test]
        public void Test1SettlementMonitorEvent()
        {
            var expected = new EventProvider();
            _authorizationPage
                .GoToPage()
                .Authorize();
            var actual = _settlementMonitorPage
                .GoPage()
                .CloseDashboard()
                .FilterByDateInCalendar("01.06.19")
                .ClickOnEventInEventTree("Футбол", "Австралия", "Виктория. Национальная Премьер-лига")
                .SelectEtapSobitiya("Finished")
                .RefreshEvenTree()
                .SelectEvent();

            Assert.Multiple(() =>
            {
                Assert.That(actual.EventTime, Is.EqualTo(expected.EventTime));
                Assert.That(actual.EventDate, Is.EqualTo(expected.EventDate));
                Assert.That(actual.EventName, Is.EqualTo(expected.EventName));
                Assert.That(actual.EventDescription, Is.EqualTo(expected.EventDescription));
                Assert.That(actual.EventAlert, Is.EqualTo(expected.EventAlert));
                Assert.That(actual.EventStage, Is.EqualTo(expected.EventStage));
                Assert.That(actual.EventScore, Is.EqualTo(expected.EventScore));
                Assert.That(actual.EventSettlementState, Is.EqualTo(expected.EventSettlementState));
            });
        }

        [Test]
        public void Test2SettlementMonitorEvent()
        {
            _authorizationPage
                .GoToPage()
                .Authorize();
            var expected = new BetInfoProvider();
            var actual = _settlementMonitorPage
                .GoPage()
                .CloseDashboard()
                .FilterByDateInCalendar("01.06.19")
                .InputEventName("Мельбурн")
                .ClickOnEvent()
                .ClickOnEventInRightPanel()
                .CloseDashboard()
                .ClickOnBetInfo()
                .GetBetinfo();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected.EventTime, actual.EventTime);
                Assert.AreEqual(expected.BetStatus, actual.BetStatus);
                Assert.AreEqual(expected.BetResult, actual.BetResult);
                Assert.AreEqual(expected.ResultSource, actual.ResultSource);
                Assert.AreEqual(expected.EventName, actual.EventName);
                Assert.AreEqual(expected.MarketName, actual.MarketName);
                Assert.AreEqual(expected.Comment, actual.Comment);
            });
        }

        [Test]
        public void Test3SettlementMonitorEvent()
        {

            var insertedChannel = "Desktop";
            var expectedChannel = ToMapChannel(insertedChannel);
            var insertedDate = "20.05.2019 02:30:00";
            DateTime expectedDate = DateTime.Parse(insertedDate, CultureInfo.CreateSpecificCulture("de-DE"));
            _authorizationPage
                .GoToPage()
                .Authorize();
            _settlenemtMonitorEventPage
                .GoToPage()
                .CloseDashboard()
                .ClickOnFilterButton()
                .InsertDateFrom(insertedDate)
                .InsertAmount("От","2")
                .InsertAmount("До","5")
                .InsertTextIntoDropbown("Segment", "Без статуса")
                .ClickOnEmptySpaceInFilter("Segment")
                .InsertTextIntoDropbown("Channel", insertedChannel)
                .ClickOnEmptySpaceInFilter("Channel")
                .PressConfirmButton()
                .PressPlayerId();
            _playerHistoryPage.GotoPage();
            Assert.True(_playerHistoryPage.IsActiveTabEquals("BET HISTORY"));
            var actual = _playerHistoryPage.GetBetInfoFromPlayerHistory();
            Assert.AreEqual(expectedChannel, actual.Channel);
            var acceptedDateRaw = actual.BetAcceptTime.Replace("\r\n", " ");
            DateTime acceptedDate = DateTime.Parse(acceptedDateRaw, CultureInfo.CreateSpecificCulture("de-DE"));
            Assert.True(expectedDate < acceptedDate);
        }


        [Test]
        public void Test4BME()
        {
            string dateFrom = "01.06.2019 00:00:00";
            string dateTo = "04.06.2019 00:00:00";
            string playerId = "087210296";
            _authorizationPage.GoToPage();
            _authorizationPage.Authorize();
            _BMEPage.GoToPage();
            _BMEPage.FilterByItem("Время приема", "Временной интервал");
            _BMEPage.FilterByDate(dateFrom, dateTo);
            _BMEPage.InsertPlayerID(playerId);
            _BMEPage.ClickSubmitInFilter();
            Assert.True(_BMEPage.ComparePlayerIdForAllElementsWithFilteredValue(playerId));
            Assert.True(_BMEPage.CompareAcceptTimeForAllElementsWithFilteredValue(dateFrom));
        }

        [Test]
        public void Test5BEFE()

        {
            string dateFrom = "01.06.2019 00:00:00";
            string dateTo = "04.06.2019 00:00:00";
            string playerId = "087210296";
            _authorizationPage.GoToPage();
            _authorizationPage.Authorize();
            _BMEPage.GoToPage();
            _BMEPage.FilterByItem("Время приема", "Временной интервал");
            _BMEPage.FilterByDate(dateFrom, dateTo);
            _BMEPage.InsertPlayerID(playerId);
            _BMEPage.ClickSubmitInFilter();
            var eventNameFE = _BMEPage.GetEventNameForAllElements();
            var loginProviderMonitor = new LoginProviderMonitor();
            _settlementMonitorRequest.AuthorizeInMonitor(loginProviderMonitor);
            var eventNamesBE = _settlementMonitorRequest.RequestBetViewBets();
            eventNameFE.CompareToList(eventNamesBE);


        }

        

    }
}


