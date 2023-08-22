using Microsoft.VisualBasic;

namespace BinanceTradingBot.Models.Requests;

public class FetchMarketDataRequest
{
    public string Symbol { get; set; } = null!;
    public DateTime Date { get; set; }
    public DateInterval Interval { get; set; }
    public int Duration { get; set; }


}