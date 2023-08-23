using BinanceTradingBot.Models;
using BinanceTradingBot.Models.Requests;
using BinanceTradingBot.Strategies;
using Microsoft.VisualBasic;

var bot = new TradingBot();
var startTradingRequest = new StartTradingRequest
{
    Symbol = "BTCUSDT",
    Interval = DateInterval.Minute,
    Duration = 5,
    Date = DateTime.Today.AddDays(-5),
    Strategy = new HourlyRotationStrategy(),
    Exchange = new Exchange(100_000)
};
await bot.StartTradingAsync(startTradingRequest);

startTradingRequest.Duration = 1;
startTradingRequest.Interval = DateInterval.Hour;
startTradingRequest.Exchange = new Exchange(100_000);
await bot.StartTradingAsync(startTradingRequest);

startTradingRequest.Duration = 1;
startTradingRequest.Interval = DateInterval.Day;
startTradingRequest.Exchange = new Exchange(100_000);
await bot.StartTradingAsync(startTradingRequest);

startTradingRequest.Exchange = new Exchange(1_000_000);
await bot.StartTradingAsync(startTradingRequest);