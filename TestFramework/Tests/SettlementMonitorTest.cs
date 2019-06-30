using NUnit.Framework;
using System;
using System.Globalization;
using TestFramework.DataProvider;
using TestFramework.Pages;
using TestFramework.Pages.Monitor;
using TestFramework.Requests;
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
        public BetsMonitorPage _betsMonitorPage;

        [SetUp]
        public void BeforeTest()
        {
            _settlementMonitorRequest = new BetViewRequest();
            _authorizationPage = new AuthorizationMonitor();
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlenemtMonitorEventPage = new SettlenemtMonitorEventPage();
            _playerHistoryPage = new PlayerHistoryPage();
            _betsMonitorPage = new BetsMonitorPage();
        }

        [Test]
        public void Test1SettlementMonitorTreeEventDataCheck()
        {
            var DateFrom = "01.06.19";
            var Sport = "Футбол";
            var Category = "Австралия";
            var Tournament = "Виктория. Национальная Премьер-лига";
            var EtapSobitiya = "Finished";

            var expected = new EventProvider();
            _authorizationPage
                .GoToPage()
                .Authorize();
            var actual = _settlementMonitorPage
                .GoPage()
                .CloseDashboard()
                .FilterByDateInCalendar(DateFrom)
                .ClickOnEventInEventTree(Sport, Category, Tournament)
                .SelectEtapSobitiya(EtapSobitiya)
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
        public void Test2SettlementMonitorBetInfoDataCheck()
        {
            var DateFrom = "01.06.19";
            var EventName = "Мельбурн";

            _authorizationPage
                .GoToPage()
                .Authorize();
            var expected = new BetInfoProvider();
            var actual = _settlementMonitorPage
                 .GoPage()
                 .CloseDashboard()
                 .FilterByDateInCalendar(DateFrom)
                 .InputEventName(EventName)
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
        public void Test3SettlementMonitorEventFiltteredDataCheck()
        {
            var actualDate = "20.05.2019 02:30:00";
            var actualAmountFrom = "2";
            var actualAmountTo = "5";
            var actualSegment = "Без статуса";
            var actualChannel = "Desktop";

            var expectedChannel = ToMapChannel(actualChannel);
            DateTime expectedDate = DateTime.Parse(actualDate, CultureInfo.CreateSpecificCulture("de-DE"));

            _authorizationPage
                .GoToPage()
                .Authorize();
            _settlenemtMonitorEventPage
                .GoToPage()
                .CloseDashboard()
                .ClickOnFilterButton()
                .InsertDateFrom(actualDate)
                .InsertAmount("От", actualAmountFrom)
                .InsertAmount("До", actualAmountTo)
                .InsertTextIntoDropbown("Segment", actualSegment)
                .InsertTextIntoDropbown("Channel", actualChannel)
                .PressConfirmButton()
                .PressFirtsPlayerIdInTable();
            _playerHistoryPage.GotoPage();
            Assert.True(_playerHistoryPage.IsActiveTabEquals("BET HISTORY"));
            var actual = _playerHistoryPage.GetBetInfoFromPlayerHistory();
            Assert.AreEqual(expectedChannel, actual.Channel);
            var acceptedDateRaw = actual.BetAcceptTime.Replace("\r\n", " ");
            DateTime acceptedDate = DateTime.Parse(acceptedDateRaw, CultureInfo.CreateSpecificCulture("de-DE"));
            Assert.True(expectedDate < acceptedDate);
        }


        [Test]
        public void Test4BetsMonitorFiltteredDataCheck()
        {
            string dateFrom = "01.06.2019 00:00:00";
            string dateTo = "04.06.2019 00:00:00";
            string playerId = "087210296";

            _authorizationPage
                .GoToPage()
                .Authorize();
            _betsMonitorPage
                .GoToPage()
                .FilterByItem("Время приема", "Временной интервал")
                .FilterByDate(dateFrom, dateTo)
                .InsertPlayerID(playerId)
                .ClickSubmitInFilter();
            Assert.True(_betsMonitorPage.ComparePlayerIdForAllElementsWithFilteredValue(playerId));
            Assert.True(_betsMonitorPage.CompareAcceptTimeForAllElementsWithFilteredValue(dateFrom));
        }

        [Test]
        public void Test5BetsMonitorCompareBMEfrontvsBetViewResponce()

        {
            string dateFrom = "01.06.2019 00:00:00";
            string dateTo = "04.06.2019 00:00:00";
            string playerId = "087210296";

            var loginProviderMonitor = new LoginProviderMonitor();

            _authorizationPage
                .GoToPage()
                .Authorize();
            _betsMonitorPage
                .GoToPage()
                .FilterByItem("Время приема", "Временной интервал")
                .FilterByDate(dateFrom, dateTo)
                .InsertPlayerID(playerId)
                .ClickSubmitInFilter();
            var eventNameFE = _betsMonitorPage.GetEventNameForAllElements();
            _settlementMonitorRequest.AuthorizeInMonitor(loginProviderMonitor);
            var eventNamesBE = _settlementMonitorRequest.RequestBetViewBets();
            CollectionAssert.AreEqual(eventNameFE, eventNamesBE);
        }

    }
}