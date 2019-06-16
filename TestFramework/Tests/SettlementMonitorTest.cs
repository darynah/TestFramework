using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Linq;
using TestFramework.DataProvider;
using TestFramework.Pages;
using static TestFramework.DataProvider.ChannelMapper;

namespace TestFramework.Tests
{
    public class SettlementMonitorTest : _BaseUITest
    {
        public AuthorizationMonitor _authorizationPage;
        public SettlementMonitorPage _settlementMonitorPage;
        public SettlenemtMonitorEventPage _settlenemtMonitorEventPage;
        public PlayerHistoryPage _playerHistoryPage;
        public BMEPage _BMEPage;

        [SetUp]
        public void BeforeTest()
        {
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
            var actual = _settlementMonitorPage
                .GoPage()
                .Authorize()
                .CloseDashboard()
                .FilterByDateInCalendar("01.06.19")
                .ClickOnEventInEventTree()
                //.SelectEtapSobitiya()
                .SelectEvent();

            Assert.Multiple(() =>
            {
                Assert.That(actual.eventTime, Is.EqualTo(expected.eventTime));
                Assert.That(actual.eventDate, Is.EqualTo(expected.eventDate));
                Assert.That(actual.eventName, Is.EqualTo(expected.eventName));
                Assert.That(actual.eventDescription, Is.EqualTo(expected.eventDescription));
                Assert.That(actual.eventAlert, Is.EqualTo(expected.eventAlert));
                Assert.That(actual.eventStage, Is.EqualTo(expected.eventStage));
                Assert.That(actual.eventScore, Is.EqualTo(expected.eventScore));
                Assert.That(actual.eventSettlementState, Is.EqualTo(expected.eventSettlementState));
            });
        }

        [Test]
        public void Test2SettlementMonitorEvent()
        {
            var expected = new BetInfoProvider();
            var actual = _settlementMonitorPage
                .GoPage()
                .Authorize()
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
                Assert.AreEqual(expected.eventTime, actual.eventTime);
                Assert.AreEqual(expected.betStatus, actual.betStatus);
                Assert.AreEqual(expected.betResult, actual.betResult);
                Assert.AreEqual(expected.resultSource, actual.resultSource);
                Assert.AreEqual(expected.eventName, actual.eventName);
                Assert.AreEqual(expected.marketName, actual.marketName);
                Assert.AreEqual(expected.comment, actual.comment);
            });
        }

        [Test]
        public void Test3SettlementMonitorEvent()
        {

            var insertedChannel = "Desktop";
            var expectedChannel = ToMapChannel(insertedChannel);
            var insertedDate = "20.05.2019 02:30:00";
            DateTime expectedDate = DateTime.Parse(insertedDate, CultureInfo.CreateSpecificCulture("de-DE"));

            _settlenemtMonitorEventPage
                .GoToPage()
                .Authorize()
                .ClickOnFilterButton()
                .InsertDate(insertedDate)
                .InsertAmountFrom("2")
                .InsertAmountTo("5")
                .InsertSegment("Без статуса")
                .ClickOnEmptySpaceInFilter("Segment")
                .InsertChannel(insertedChannel)
                .ClickOnEmptySpaceInFilter("Channel")
                .PressConfirmButtonn()
                .PressPlayerId();
            _playerHistoryPage.GotoPage();

            Assert.True(_playerHistoryPage.IsActiveTabEquals("BET HISTORY"));
            var actual = _playerHistoryPage.GetBetInfoFromPlayerHistory();
            Assert.AreEqual(expectedChannel, actual.channel);
            var acceptedDateRaw = actual.betAcceptTime.Replace("\r\n", " ");
            DateTime acceptedDate = DateTime.Parse(acceptedDateRaw, CultureInfo.CreateSpecificCulture("de-DE"));
            Assert.True(expectedDate < acceptedDate);
        }


        [Test]
        public void Test4BME()
        {
            string dateFrom = "01.06.2019 00:00:00";
            string dateTo = "04.06.2019 00:00:00";
            _authorizationPage.GoToPage();
            _authorizationPage.Authorize();
            _BMEPage.GoToPage();
            _BMEPage.Filter("Время приема", "Временной интервал");
            _BMEPage.FilterByDate(dateFrom, dateTo);
            //_BMEPage.ClickonFilterArrow("ID игрока");
            //_BMEPage.InsertPlayerID("087210296");
            _BMEPage.Submit();
        }

        [Test]
        public void Test401BME()
        {
            string actualDate = "01.06.2019 00:30:00";
            _authorizationPage.GoToPage();
            _authorizationPage.Authorize();
            _BMEPage.GoToPageFilter();
            Assert.True(_BMEPage.PlayerIdAll("087210296"));
            Assert.True(_BMEPage.AcceptTimeAll(actualDate));
        }
    }
}


