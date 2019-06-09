using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestFramework.DataProvider;
using TestFramework.Pages;

namespace TestFramework.Tests
{
    public class SettlementMonitorTest : _BaseUITest
    {
        public SettlementMonitorPage _settlementMonitorPage;
        public SettlenemtMonitorEventPage _settlenemtMonitorEventPage;
        public PlayerHistoryPage _playerHistoryPage;

        [SetUp]
        public void BeforeTest()
        {
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlenemtMonitorEventPage = new SettlenemtMonitorEventPage();
            _playerHistoryPage = new PlayerHistoryPage();
        }

        [Test]
        public void Test1SettlementMonitorEvent()
        {
            var expected = new EventProvider();
            var actual =_settlementMonitorPage
                .Authorize()
                .SelectCalendar()
                .ClickOnCalendarDate()
                .ClickOnEventInEventTree()
                .SelectEtapSobitiya()
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
                .Authorize()
                .SelectCalendar()
                .ClickOnCalendarDate()
                .InputEventName("Мельбурн")
                .ClickOnEvent()
                .ClickOnEventInRightPanel()
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
            var expectedSegment = "Без статуса";
            var expectedChannel = "Desktop";
            _settlementMonitorPage.Authorize();
            _settlenemtMonitorEventPage.ClickOnFilterButton()
                .InsertDate("20.05.2019 02:30:00")
                .InsertAmountFrom("2")
                .InsertAmountTo("5")
                .InsertSegment(expectedSegment)
                .InsertChannel(expectedChannel)
                .PressConfirmButtonn()
                .PressPlayerId();
            Assert.True(_playerHistoryPage.IsActiveTabEquals("Bet History"));
            var actual = _playerHistoryPage.GetBetInfoFromPlayerHistory();
            Assert.AreEqual(expectedChannel, actual.channel);
        }
    }
}
