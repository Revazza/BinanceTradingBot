using BinanceTradingBot.Interfaces;
using BinanceTradingBot.Models.Requests;
using BinanceTradingBot.Strategies;

namespace BinanceTradingBot.Models;

public class TradingBot
{

    public async Task StartTradingAsync(StartTradingRequest request)
    {
        var marketData = await FetchMarketDataAsync(request);
        //marketData.Display();
        Console.WriteLine("Hourly Rotation Strategy In Action");
        Console.WriteLine($"Invested Amount: {request.Exchange.Balance:N3}$");

        ExecuteStrategy(request.Strategy, request.Exchange, marketData);
        Console.WriteLine();
    }

    private void ExecuteStrategy(
        ITradingStrategy strategy,
        IExchange exchange,
        List<MarketData> marketData)
    {
        // we are buying every stock we can get
        // and then selling all of them hourly

        foreach (var data in marketData)
        {
            if (strategy.IsTimeToBuy(data))
            {
                exchange.Buy(data.OpenPrice);
            }
            if (strategy.IsTimeToSell(data))
            {
                exchange.Sell(data.ClosePrice);
            }
        }
        Console.WriteLine($"Current Balance: {exchange.Balance:N3}$");

        exchange.CalculateProfit();
    }

    private async Task<List<MarketData>> FetchMarketDataAsync(StartTradingRequest request)
    {
        var fetchDataRequest = new FetchMarketDataRequest
        {
            Symbol = request.Symbol,
            Date = request.Date,
            Duration = request.Duration,
            Interval = request.Interval,
        };

        return await new BinanceDataFetcher().FetchAsync(fetchDataRequest);
    }

}