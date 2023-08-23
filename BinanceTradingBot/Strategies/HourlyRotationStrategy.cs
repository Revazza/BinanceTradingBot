using BinanceTradingBot.Interfaces;
using BinanceTradingBot.Models;

namespace BinanceTradingBot.Strategies;

public class HourlyRotationStrategy : ITradingStrategy
{
    public bool IsTimeToBuy(MarketData data)
    {
        var currentTime = data.OpenTimeStamp;
        var roundedDownTime = CalculateHourlyBoundary(currentTime);

        return data.OpenTimeStamp == roundedDownTime;
    }

    public bool IsTimeToSell(MarketData data)
    {
        var currentTime = data.CloseTimeStamp;
        var roundedUpTime = CalculateHourlyBoundary(currentTime, 1).AddSeconds(-1);
        // tiks and miliseconds comparison was a problem between 'currentTime' and 'roundedUpTime'
        // so I had to use ToString("h:mm tt")
        return currentTime.ToString("h:mm tt") == roundedUpTime.ToString("h:mm tt");
    }

    private DateTime CalculateHourlyBoundary(DateTime date, int hour = 0)
    {
        return date.Date.AddHours(date.Hour + hour);
    }

}

