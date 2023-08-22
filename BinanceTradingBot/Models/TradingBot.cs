using BinanceTradingBot.Models.Requests;

namespace BinanceTradingBot.Models;

public class TradingBot
{

    public async Task StartTradingAsync(StartTradingRequest request)
    {
        var data = await FetchMarketDataAsync(request);
        //data.Display();

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