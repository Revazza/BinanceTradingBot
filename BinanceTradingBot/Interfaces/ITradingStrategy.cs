using BinanceTradingBot.Models;

namespace BinanceTradingBot.Interfaces;

public interface ITradingStrategy
{
    public bool IsTimeToBuy(MarketData data);
    public bool IsTimeToSell(MarketData data);
}
