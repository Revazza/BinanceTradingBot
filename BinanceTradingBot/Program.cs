using BinanceTradingBot.Models;
using BinanceTradingBot.Models.Requests;
using Microsoft.VisualBasic;

var bot = new TradingBot();
var startTradingRequest = new StartTradingRequest
{
    Symbol = "BTCUSDT",
    Interval = DateInterval.Minute,
    Duration = 5,
    Date = DateTime.Today.AddDays(-5),
};
await bot.StartTradingAsync(startTradingRequest);

startTradingRequest.Duration = 1;
startTradingRequest.Interval = DateInterval.Hour;
await bot.StartTradingAsync(startTradingRequest);

startTradingRequest.Duration = 1;
startTradingRequest.Interval = DateInterval.Day;
await bot.StartTradingAsync(startTradingRequest);