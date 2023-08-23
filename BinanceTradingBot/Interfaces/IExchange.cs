using BinanceTradingBot.Models;

namespace BinanceTradingBot.Interfaces;

public interface IExchange
{
    public decimal Balance { get; }
    public decimal Profit { get; set; }
    public void Buy(decimal stockPrice);
    public void Sell(decimal stockPrice);
    public decimal CalculateProfit();

}