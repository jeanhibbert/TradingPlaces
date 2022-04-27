using Microsoft.Reactive.Testing;
using NUnit.Framework;
using System;
using System.Reactive;
using System.Reactive.Linq;
using TradingPlaces.Resources;
using TradingPlaces.Server.Domain;
using TradingPlaces.Server.Domain.Dtos;
using TradingPlaces.Server.Domain.Model;

namespace TradingPlaces.UnitTests
{
    public class TradeStrategyTestFixture
    {

        private TestScheduler _testScheduler;

        [SetUp]
        public void Setup()
        {
            _testScheduler = new TestScheduler();
        }

        [Test]
        public void TradeStrategyTestFixture_StrategyWillPass_OnExpectedPercetage_Increase()
        {
            IStrategyDetails strategyDetails = new StrategyDetailsDto
            {
                Ticker = "MSFT",
                Instruction = BuySell.Buy,
                PriceMovement = 1,
                Quantity = 10
            };

            var priceStream = _testScheduler.CreateHotObservable(
                 OnNext(1000, new PriceDto ("MSFT", null, 100.0M) ),
                 OnNext(2000, new PriceDto("MSFT", null, 110.0M)),
                 OnNext(3000, new PriceDto("MSFT", null, 120.0M))
                 );

            ITradeStrategy tradeStrategy = new TradeStrategy(strategyDetails, priceStream);
            _testScheduler.AdvanceBy(4000);
            //Assert.IsTrue(tradeStrategy.IsReadyToExecute(null))
                       
            var output = tradeStrategy.Execute();

        }

        private Recorded<Notification<T>> OnNext<T>(long ticks, T value)
        {
            return new Recorded<Notification<T>>(
                ticks,
                Notification.CreateOnNext(value));
        }
    }
}